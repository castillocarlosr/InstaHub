Software Requirements
Vision
What is the vision of this product?
To create an online chat platform for users to get together and have conversation.
What pain point does this project solve?
Google Hangouts is a great platform but may have a short life span (https://www.theverge.com/2018/11/30/18120199/google-hangouts-consumers-2020-chat-app-shut-down). 
As developers we would love to have a chat platform that could integrate a shared environment for coding, like a shared codepen.
Why should we care about your product?
Snow days are killer for fast paced courses like Code Fellows. Having a chat platform that user’s could share code and discuss ideas would be a excellent tool.
Scope (In/Out)
IN - What will your product do
The app will provide a messaging system between users
The app will provide a list of contacts for the user in scope
Users will be able to add other users to their contacts after confirmation
Users will be able to create new conversations
Users and Guests will be able to join public conversations
OUT - What will your product not do.
The app is not going to save all of the messages over time (30 per hub or all for day of)
The app will not have a screen share feature.
MVP
What will your MVP be. What is your expected minimum end product?
1. Our MVP will be a functioning site that allows a user to register, login, and be able to chat with one hub.
Stretch
What stretch goals are you going to aim for?
1. Able to implement and use a video chat function for one-to-one only.
2. Able to embed and use CodePpen with another user.
3. Have a moderator for the group chat.  Most likely the person who created the group.
Functional Requirements
List the functionality of your product. This will consist of tasks such as the following:
A user can register and login securely.  
A user can login using a 3rd party OAuth.
A user will have the ability to add other users to the group they created.
A user will have the ability to send message each user individually.
A user will have the ability to send messages in a group chat.
A user will be able to join and send messages in a public chat.
A user will only be able to see the most recent 30 messages.
A user will be able to set to offline when not logged in.
A user will be be able to use emojis.
A user will be able to attach an image to show on the chat.
A user will the new messages appear right away.
A random user will be able to send messages and join chats, with no saved history. 
Non-Functional Requirements
Non-functional requirements are requirements that are not directly related to the functionality of the application.
Examples include:
Security.  Have the user securely use 3rd party OAuth.
Usability.  Having sounds and visualizations will not impede the core function.
Testability.  Have the xUnit tests pass for Get/Set, and databases.
Pick 2 Non-functional requirements and describe its functionality in your application. 
1.  The 3rd party OAuth would use twitter, facebook, microsoft, or google login instead of registering.  If they cant use the 3rd party OAuth login the site will still function. 
2.  The user will be comfortable to use the site in 2 minutes.
3. There will be tests for all the methods and get/set functions.  The test will ensure the application runs without bugs and will not impede the functionality.   Code coverage will have a minimum to have 70% coverage.
Data Flow
A user comes to our site, and can see the dashboard. They are not logged in and thus only have access to public hubs. They can join into those hubs and contribute via an anonymous randomly generated username. 

A user can login or register in the upper corner. They will have the option to login via OAuth or via email and password. They will be able to register with an email and password or with OAuth.

After logging in the user will see their list of active conversations as well as a tab to see all their contacts. 

When a user wants to start a new conversation they will be able to click a button in their list of conversations and see a view that allows them to decide the type of conversation and the ability to add any user to the conversation via email address and SendGrid.

A user will be able to click on any conversation and have it open a chat window on the dashboard. Here the user can see the last ## of messages and type to add to the message stream.

A user will be notified that a new message has come into a chat by a notification sound and a flashing header for the hub.
