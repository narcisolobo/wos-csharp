# Group Activity: Art Class Hierarchy
**Objective**:  
Create a base `Art` class and at least three subclasses that inherit from `Art`. Each subclass should represent a different type of artwork, such as `OilPainting`, `Sculpture`, and `DigitalArt`. Implement methods to display details about the artwork.

## Instructions
1. Define the `Art` Class:
   - Add properties for `Title`, `Artist`, and `Year`.
   - Add a constructor method.
   - Add a `DisplayDetails` `virtual` method.
2. Create Subclasses:
   - Each group will create at least three subclasses that inherit from `Art`.
   - In each subclass, add a constructor method that calls the `base` class constructor.
   - Each subclass should add at least one unique property. For example, an `OilPainting` subclass might have a `Medium` property, to represent the medium used by the artist.
   - Use Polymorphism to `override` the `DisplayDetails` method in each subclass.
3. Test and Demonstrate:
   - Create instances of each subclass.
   - Call the `DisplayDetails` method on a list of `Art` objects.
   - Print the details of each artwork to the console.