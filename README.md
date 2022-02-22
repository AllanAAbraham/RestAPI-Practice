# Microsoft Flipgrid Coding Challenge
### Allan Abraham

This project was created using Visual Studio
Code was tested with Postman

### To run code:
1. Pull from master branch in github
2. Open code in Visual Studio (Make sure to open Challenge2.sln so Nuget can pull in dependencies)
3. Run Challenge2

### Settings:
There are two configurable settings found in appsettings.json

"NEntries": 5
This is the default setting of the number of entries that can be displayed in each page. 
A user can overwrite this entry with an optional string parameter.

"Datapath": "/TestData/leaderboard2.json"
If the user does not add entries into the API using post, the API will add data entries from the json file listed above.

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
	}
]

