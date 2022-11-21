using System;

namespace Sign_In_Page.Models;

public class Human
{
    public string? FullName { get; set; } = default!;
    public string? Title { get; set; } = default!;
    public string? Email { get; set; } = default!;
    public string? Slogan { get; set; } = default!;

    public DateTime? Birthday { get; set; } = default!;
    public string? Country { get; set; } = default!;
    public string? Region { get; set; } = default!;
    public string? PostalCode { get; set; } = default!;
    public string? PhoneNumber { get; set; } = default!;


    public decimal Posts { get; set; } = default!;
    public decimal Messages { get; set; } = default!;
    public decimal Members { get; set; } = default!;

    public string? PictureUrl { get; set; } = default!;

    public Human()
    {

    }

    public Human(string? fullName, string? title, string? email, string? pictureUrl, DateTime? birthday, string? country, string? region, string? postalCode, string? phoneNumber, decimal posts, decimal messages, decimal members, string? slogan)
    {
        FullName = fullName;
        Title = title;
        Email = email;
        PictureUrl = pictureUrl;
        Birthday = birthday;
        Country = country;
        Region = region;
        PostalCode = postalCode;
        PhoneNumber = phoneNumber;
        Posts = posts;
        Messages = messages;
        Members = members;
        Slogan = slogan;
    }

}
