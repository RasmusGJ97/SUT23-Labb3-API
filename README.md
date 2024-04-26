# SUT23-Labb3-API

How to call on the API:

Interest:
- Get all interests: writes out all the interest from the database.
- Get interest by id: lets the user type in the id of an interest and gets the specific information from that id.
- Add interest: Lets the user add a new interest to the database with this kodblock =>
  {
  "interestName": "string",
  "interestDescription": "string"
  }
  Where string can be changed to the name and description the user wants for the interest.

Link:
- Get all links: writes out all the links from the database.
- Get link by id: lets the user type in the id of a link and gets the specific information from that id.
- Add link: lets the user add a new link to the database with this kodblock =>
  {
  "linkName": "string"
  }
  Where string can be changed to the link URL.

Person:
- Get all persons: writes out all person from the database.
- Get person by id: lets the user type in the id of a person and get the specific information from that id.
- Add person: lets the user add a new person to the database with this kodblock =>
  {
  "personName": "string",
  "phoneNr": "string"
  }
  where string can be changed to to the name and phonenumber the user want for that person.

  IPL (InterestPersonLink):
  - Get all connections: writes out all the connections made between a person, interest and link.
  - Get person by id: lets the user type in the id of a person and get the specific information from that id.
  - Connect interest and links to a person: lets the user connect links and interest to a specific person by entering the persons id, the interests id and the links id.
  - Get all interests for a person: lets the user get all the interests from a person by typing in the id for the person.
  - Get all links for a person: lets the user get all the links from a person have by typing in the id for the person.
