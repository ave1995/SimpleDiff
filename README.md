# Simple Diff

## Description

Simple ASP.NET Core 6.0 API that compares two inputs (more details in the assignment [here](#The-Assignment)). 
Uses MSSQL database to store inputs, docker compose file attached for MSSQL image. 

Solution includes an integration test project that uses InMemoryDatabase, here you can test the API without using MSSQL. Also includes a test project for internal logic with fake data.

## Docker Scripts

### MSSQL Image download and run
```console
docker-compose up -d
```
### MSSQL Image stop
```console
docker-compose down
```

## Limitations

- Input has a length restriction [StringLength(500)]

- I don't check if one input is already in the DB and I don't inform the user

- User has to wait for the difference result, Api could have a background queue to compare inputs and store results in DB

- Class DbInitialiser always deletes the schema and creates a new one (we can comment ensure methods and uncomment the migrate method)

## The Assignment

Provide 2 HTTP endpoints that accepts base64-encoded JSON of following format
 
- <host>/v1/diff/<ID>/left
- example: curl -X POST "<host>/v1/diff/<ID>/left" -H "accept: */*" -H "Content-Type: application/custom" -d
"\"eyJpbnB1dCI6InRlc3RWYWx1ZSJ9\""
- <host>/v1/diff/<ID>/right
- example: curl -X POST "<host>/v1/diff/<ID>/right" -H "accept: */*" -H "Content-Type: application/custom" -
d "\"eyJpbnB1dCI6InRlc3RWYWx1ZSJ9\""

The provided JSON data needs to be diff-ed and the results shall be available on a third end point
- <host>/v1/diff/<ID>

The results shall provide the following info in JSON format ( structure is up to you)
- If value of the "input" property of diffed JSONs is equal, just return that information saying “inputs were equal”. No need to return
compared values.
- If value of the "input" property of diffed JSONs is not of equal size, just return that information “inputs are of different size”. No need
to return compared values.
- If value of the "input" property of diffed JSONs has the same size, perform a simple diff - return offsets (in both values of the "input"
property) and lengths (in both values of the "input" property) of the differences.

## Must haves

- Solution written in C# - strongly preferred is to use .NET CORE ( NET 6.0 )
- Provide a test client (can be command line, integration test …..) to call the API
- Documentation in code
- Describe limitations of the solution

