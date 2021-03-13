# KanbanBoard
This is a two part project, the first is an asp.net api that controles the data storage of the state of the board. The second is a angular.js web application that contains the ui for the board as well as the javascript files that interact with the api

To run this you will need to use at least visual studio 2017. After down loading the two projects you will want to open the api in visual studio, this is located in the file named Kanban. You will then want to run the project once as a IIS Express to have it running in the backend while running the web application. Next you will need to open an second instence of visual studio and open the Kanban client, this is located in the KanbanBoard folder. You can run the web application from visual studio. 
If this changes I will make any necessary updates here.

Some things I would have liked to have done:
  API-
    Added some more functions to stream line some of the code that is used for getting the tempary instence as well as the datastore file.
    Add a method for editing description or user or date.
    Add a method for deleting a card
    
  Client
    Add a field to choose the user that card is for. 
    Have a user log in
    Have a way to delete
    Be able to edit a card
