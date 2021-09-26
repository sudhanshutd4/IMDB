Configuration steps:-
Execute the script present in the scripts Folder in your database.
Please change the value of tag DefaultConnection in appsettings.json file as per your environemt.


1. List all movies with actor and producer information. Return all the movies with details. Each
movie information consists of - Name, Date of Release, Producer, and all actors of the movie.
url:-https://localhost:44366/api/Movies
Request type:GET
Sample Response

[
  {
    "name": "Main Hoon Na",
    "description": "Fantasic movie",
    "dateOfRelease": "2021-09-24",
    "producerName": "sudhanshu",
    "actorsNames": [
      "pankaj tripathi",
      "preity g zinta"
    ]
  },
  {
    "name": "Bhooth Nath",
    "description": "Fantasic movie",
    "dateOfRelease": "2021-09-24",
    "producerName": "sudhanshu",
    "actorsNames": [
      "pankaj tripathi"
    ]
  }
]

2. Create a movie: can choose multiple actors and a producer.
url:-https://localhost:44366/api/Movies
Request type:POST
Sample Request
{
  "name": "hero",
  "description": "love story of a spy",
  "dateOfRelease": "2021-09-25",
  "producerName": "producerName",
  "actorsNames": [
    "shyam","ram"
  ]
}

Response
Incase of success :-movie Added successfully
Incase of Failure :- Appropriate reason for Failure.

3. Edit a movie: update any movie information (including actors and producer).
url:-https://localhost:44366/api/Movies/2 
where 2 is the id of the movie that you want to edit.
Request type:PUT
Sample Request
{
  "name": "string",
  "description": "Hello",
  "dateOfRelease": "2021-09-25T18:55:13.542Z",
  "producerName": "bony kapoor",
  "actorsNames": [
    "siddharth shukla"
  ]
}

Response
Incase of success :-Movie Edited successfully
Incase of Failure :- Appropriate reason for Failure.


4. Create an actor: create a new actor in the database
url :-https://localhost:44366/api/Actors
Request type:POST
Request Sample
{
  "name": "sudhanshu Jandial",
  "description": "He is one of the most hardworking actor.",
  "dateOfBirth": "1997-09-25",
  "gender": "male"
}

Response
Incase of success :-Producer Created successfully
Incase of Failure :- Appropriate reason for Failure.


5. Create a producer: create a new producer in the database
url :- https://localhost:44366/api/Producers
Request type:POST
Request sample

{
  "name": "Sanjay Gupta",
  "description": "A good producer",
  "dateOfBirth": "1952-09-02",
  "company": "Company Pvt Ltd",
  "gender": "male"
}

Response
Incase of success :-Producer Created successfully
Incase of Failure :- Appropriate reason for Failure. 


 

