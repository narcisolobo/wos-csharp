# Belt Review - The WatchList

Create The WatchList, a site where users can track, find, and rate the movies they love.

## MVP Features
**Login and Registration with Validations**
- Validation messages should display for unsuccessful submission
- (Registration and Login) All fields required
- (Registration) Name must have a minimum length of 2 characters
- (Registration) Valid email format
- (Registration) No duplicate emails
- (Registration) Password must have a minimum length of 8 characters
- (Registration) Password and Confirm must match
- (Login) Valid email and password

**Dashboard**
- Display all movies with information shown (not including purple marked stretch goals)
- Ability to edit a movie you made
- Ability to delete a movie you made
- Add a Movie to your WatchList link takes you to Add Movie page
- Clicking on View routes to its details page

**Movie Details**
- The movie details are displayed as shown
- Average rating shown (not including purple marked stretch goals)
- Ability to rate a movie
- Ability to edit movie if you made it
- Ability to delete movie if you made it

**New Movie**
- All fields are required
- Validation messages should display for unsuccessful submission
- Title and genre must be at least two characters
- Synopsis must be at least ten characters

**Logout/Security**
- Logout should redirect to login/register page and clear session
- Users should not be able to access any other pages unless logged in

**Relationships**
- One-to-many relationship between Users and Movies
- Many-to-many relationship between Users and Movies they have rated

**Backend**
- Use LINQ to persist and query data in a MySQL server

**Stretch Goals**
- (Register) Password must contain at least 1 uppercase letter, one lowercase letter, and 1 number
- (All Movies) Add a sort filter that sorts based on title, genre, or release date and displays correct results
- (Movie Details) Display the number of users who have rated this movie