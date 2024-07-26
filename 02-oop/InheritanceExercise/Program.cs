using InheritanceExercise.Classes;

try
{
    var testPainting = new Painting(
        "test title",
        "test artist",
        "test link",
        1959,
        "test medium"
    );
}
catch (ArgumentOutOfRangeException e)
{
    Console.WriteLine(e.ToString());
}

var inevitable = new Painting(
    "The Inevitable",
    "Joe Hesketh",
    "https://www.riseart.com/art/101692/the-inevitable-by-joe-hesketh",
    2019,
    "Oils"
);

var theBean = new Sculpture(
    "Cloud Gate",
    "Anish Kapoor",
    "https://millenniumparkfoundation.org/art-architecture/cloud-gate/",
    2006,
    "Stainless Steel"
);

var dive = new DigitalArt(
    "The Dive",
    "Lois van Baarle",
    "https://www.instagram.com/p/C1muXwusL-V/?img_index=1",
    2023,
    "Adobe Photoshop"
);

var artworks = new List<ContemporaryArt>()
{
    inevitable, theBean, dive
};

foreach (var artwork in artworks)
{
    artwork.DisplayDetails();
}
