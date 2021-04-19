# User stories

## For Friday

### As a User I want to be able to sign up for and then sign into an account so that I can begin building an art portfolio

- Require Username
- Require Password
- Required Email

### As a shy user I would like to be able to set my accout to private so only I can view it

### As a User I want to be able to "create" a piece of art to my profile. 

- Allow uploads of .txt file.
- Reject un-approved file types and give back a status code.
- Files larger than 5MB will be rejected.
- Save timestamp
- Save the Artists name
- Save Art Title
- Save a description
  - Max 250 words
- Add tags to the art piece
  - Tags are a single field of text
- Add a private or public setting default to public 

### As a User I want to be able to view art

Get all art

- View a list of public tagged art
- view the artist for a piece of art
- View a description of the art
- view the title of the art
- A user can view their own privately marked art
- View art ID

Get singular art

- Send back error if trying to view an art piece they do not have access to
  - 404 Error Not the webpage you are looking for
- Send back error if the art does not exist
  - 404 Error Not the webpage you are looking for
- Send back Title
- Send back Artist
- Send back description
- Send back Upload date
- Send back content
- Send back ID

### As an artist I would like to delete my old art because it doesn't reflect my current talents.

- require authorization of owner
- Accept the Art ID
- Mark as "deleted" don't actually delete
- return 404 for non existent
- return 204 for it worked

### As an artist I would like to change the description of a piece so that I can fix typos without needing to upload the file again.

UI
- Show current description in a text field
- Allow edit of the description.
- Make post on submit.

Post request
- Require authorization of owner
- Require Art Id
- Require new description text
- redirect to updated page

### As an artist I would like to change the privacy of my art so that I can hide art that was not well recieved.

- Goes hand in hand with "As an artist I would like to change the description of a piece so that I can fix typos without needing to upload the file again."

UI
- Add Switch UI element for public/private

Post request
- add required updated Privacy bool

### As an artist apart of a colaboration effort I would like to have an account we all can access so we can share credit for the art.

Create the group

- Require a logged in user
- Add Logged in user as Group Owner
- Require a group name
- Allow a description
- Allow privacy setting default to public 
- return Group DTO

Add members

- Authorize for Group Admin
- Require Valid user ID for addition
  - Don't allow for private users
- Allow permission level default to member
- *maybe allow added user to confirm the addition*
- Return Group DTO
- *If user ID is invalid return some sort of user not found message (???)*

Remove member

- Authorize for group admin or higher
- require group member ID with permission less than current user
- return DTO
- remove member

Change member permissions

- authroize for group admin or higher
- require group member
- require permision level less than current user
- if group member level is higher than new level throw bad request
- if permission level is higher than current user level throw bad request
- set group member permision to designated level
- return DTO

### As a curator I would like to view all the artists so I can judge them

Get all artists

- View a list of public tagged artists
- view the artist name
- view the artist ID
- view a list groups they are in *name and ID*
- view a list of Art they uploaded *name and ID*

Get singular artists

- view artist name
- view artist bio
- view a list of art *title, ID, description, and date uploaded*
- view a list of groups *name, ID, and description*
- view artist ID

### As a user I would like to view all art from my favorite artist so my search isnt cluttered with those plebeians poor attempt at art.

Get all art

- View a list of Art by Designated Artist
- view the artist for a piece of art
- View a description of the art
- view the title of the art
- only the artist can view their own privately marked art
- View art ID




Stretch goal:
- Collections
- comments





As a User I want to be able to upload a piece of art to my profile. I want to be able to drag a file from my screen to the file uploader.

- Allow uploads of Jpg, GIF, PNG, etc.
- Reject un-approved file types and give back a status code.
- Files larger than 10MB will be rejected.

 People will be able to view all non-private artwork on an artists profile.
<!-- Specificity, 3 different stories. Private, public, public user can view -->

<!-- As a User I want to be able to control who can see my art. I want to be able to show anyone or just select friends   -->

<!-- As a user I want to control who can do what over the database and APIs. If someone is just a viewer, they should only be able to view art. If someone is an artist than they can view others art, create and upload their own art, and control how that art is viewed by others.   -->
<!-- Admins should be able to manage the database and control what goes in.  -->

As a user I would like see some kind of moderation where inappropriate "art pieces" are hidden or removed from public view. A user will have a report button to report art they find inappropriate. A moderator will be able to hide and remove inappropriate pieces of art.

As a User I want to add functionality that allows users to follow others and share comments and likes on pieces of art. I would like to see the names of people who follow my and like my art or leave comments.

<!-- As a User I want others to be able to upload their art to a gallery where they can create folders of their various art pieces. They will then be able to share specific folders with others, or share them all with everyone.  -->

As a Jaded Artist whose been burned, I want to ensure I get to approve collaborator access.

- Users can invite other users to work on art pieces together  
  - Group members can invite others
  - Stretch goals:
    - Owner can invite
    - Owner can give invite rights to certain collarorators
    - Collab Owner can remove collaborators
<!-- I need to be able to give permission to someone to access the art project. -->

As a timid new artist I would like to set my art as private so only people I share it with can view it. I want to be able to make my work private or public until I am ready to share it with others.

As a viewer I would like to save specific pieces in collections so I can have themed viewing galleries. I want to be able to save my work into an "Album" so I can share all my works in one place.

As a colaborating artist, I would like to be accredited for an art piece as well as the other contributors so everyone gets fair exposure. My name should be listed on my art pieces and on any collaboration I work with alongside groups.

As an Aspiring artist I would like a public platform to display my work to broaden my viewers. I would like to see how many people have liked/viewed my art.



Top 3
As a User I want to be able to upload a piece of art to my profile. I want to be able to drag a file from my screen to the file uploader.

- Allow uploads of Jpg, GIF, PNG, etc.
- Reject un-approved file types and give back a status code.
- Files larger than 10MB will be rejected.

As a viewer I would like to save specific pieces in collections so I can have themed viewing galleries. I want to be able to save my work into an "Album" so I can share all my works in one place.

- Add to collection button on art piece
- Create a Collection
- View a Collection
- Give the collection a name
- Set as public or private
- Give it a theme
- Give the collection a media type
- Curator name available on collection
- Give the collection keywords/tags


As a Curator I want to be able to create a Collation to store art pieces

- Give the collection a name
- Give it a description
- Set it public or private
- Give it keywords or tags


As a colaborating artist, I would like to be accredited for an art piece as well as the other contributors so everyone gets fair exposure. My name should be listed on my art pieces and on any collaboration I work with alongside groups.


