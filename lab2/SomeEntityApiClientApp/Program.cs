using SomeEntityApiClientApp;

var client = new SomeEntityApiClient("https://localhost:7012/"); 

// Create
var created = await client.CreateAsync(new SomeEntity
{
    Name = "Example",
    Description = "Facade pattern test",
    Status = "Active"
});
Console.WriteLine($"Created: {created?.Id} - {created?.Name}");

// GetMany
var all = await client.GetManyAsync();
foreach (var item in all)
{
    Console.WriteLine($"{item.Id}: {item.Name} [{item.Status}]");
}

// Filter
var filter = new SomeEntityFilterBuilder()
    .WithStatus("Active")
    .WithName("Example");

var filteredEntities = await client.GetByFilterAsync(filter);

foreach (var entity in filteredEntities)
{
    Console.WriteLine($"{entity.Id}: {entity.Name} ({entity.Status})");
}

// Update
if (created != null)
{
    created.Name = "Updated Name";
    await client.UpdateAsync(created.Id, created);
}

// Delete
if (created != null)
{
    await client.DeleteAsync(created.Id);
}

// GetMany
var all2 = await client.GetManyAsync();
foreach (var item in all)
{
    Console.WriteLine($"{item.Id}: {item.Name} [{item.Status}]");
}


// --- IMAGE ENTITY DEMO ---

// Create a new entity for image testing
var imageEntity = await client.CreateAsync(new SomeEntity
{
    Name = "ImageTest",
    Description = "Entity with image",
    Status = "Active"
});

if (imageEntity != null)
{
    // Set image URL
    string imageUrl = "https://example.com/image.jpg";
    bool setImage = await client.SetImageAsync(imageEntity.Id, imageUrl);
    Console.WriteLine(setImage
        ? $"Image URL set for entity {imageEntity.Id}"
        : "Failed to set image URL");

    // Get image URL
    var retrievedUrl = await client.GetImageAsync(imageEntity.Id);
    Console.WriteLine(retrievedUrl != null
        ? $"Retrieved image URL: {retrievedUrl}"
        : "Image URL not found");

    // Get extended image entities by filter
    var extendedEntities = await client.GetImageEntitiesByFilterAsync(status: "Active");
    Console.WriteLine("Extended entities:");
    foreach (var e in extendedEntities)
    {
        Console.WriteLine($"{e.Id}: {e.Name} | {e.Status} | Image: {e.ImageUrl}");
    }

    // Delete base entity
    bool deleted = await client.DeleteAsync(imageEntity.Id);
    Console.WriteLine(deleted
        ? $"Entity {imageEntity.Id} deleted"
        : "Failed to delete entity");

    // Verify that image is also removed
    var imageAfterDelete = await client.GetImageAsync(imageEntity.Id);
    Console.WriteLine(imageAfterDelete == null
        ? "Image was deleted with entity (✔)"
        : $"Image still exists: {imageAfterDelete} (✘)");
}
else
{
    Console.WriteLine("Failed to create image test entity.");
}