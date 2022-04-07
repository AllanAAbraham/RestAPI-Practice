# Rest Practice
### Allan Abraham

This project was created using Visual Studio and was tested with Postman

### To run code:
1. Pull from master branch in github
2. Open code in Visual Studio (Make sure to run Challenge2.sln so Nuget can pull in dependencies)
3. Run Challenge2
4. Use Postman to test the endpoint { https://localhost:7118/api/leaderboard }
5. Running GET on this endpoint allows user to add entries to the API. In Postman, set Body settings to raw and json. Formatting of entry input can be viewed below.
6. Running POST on this endpoint will retrieve data within the API and display it as an output within Postman.

### Nuget packages
- Swashbuckle.AspNetCore v6.2.3
- Newtonsoft.Json v13.0.1
- Moq v4.16.1

### Settings:
There are two configurable settings found in appsettings.json

"NEntries": 5

This is the default setting of the number of entries that can be displayed in each page. 

A user can overwrite this entry with an optional string parameter.

"Datapath": "~/TestData/leaderboard2.json"

If the user does not add entries into the API using post, the API will add data entries from the json file listed above. The file listed above contains 100 entries. ""~/TestData/leaderboard.json" contains 50 entries. 

### Endpoints:

The GET Endpoint is https://localhost:7118/api/leaderboard

If no data is provided to the API, the API will pull data from a json file.

The default page number is set to 1 and number of entries per page is set to 5.

Both of these parameters can be overriden with optional query parameters as such:

https://localhost:7118/api/leaderboard?pageNum=2&n=2

The POST endpoint is https://localhost:7118/api/leaderboard

Please make sure the data is formatted as such:

[
	{
		"username": "Neil",
		"score": 8635,
		"index": 4650
	},
	{
		"username": "Serina",
		"score": 5587,
		"index": 5459
	},
	{
		"username": "Omar",
		"score": 5475,
		"index": 4432
	},
	{
		"username": "Merritt",
		"score": 7812,
		"index": 5188
	}
]

