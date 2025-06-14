using Task3;

var guest = new User { Username = "guest", IsRegistered = false, HasAccessToBook = false };
var member = new User { Username = "member", IsRegistered = true, HasAccessToBook = false };
var premium = new User { Username = "premium", IsRegistered = true, HasAccessToBook = true };

IBook guestBook = new BookProxy(guest);
IBook memberBook = new BookProxy(member);
IBook premiumBook = new BookProxy(premium);

Console.WriteLine(guestBook.ReadContent());
Console.WriteLine(memberBook.ReadContent());
Console.WriteLine(premiumBook.ReadContent());
Console.WriteLine(premiumBook.ReadContent());