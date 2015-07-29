NaNoWriMo SDK
=============
This is a wrapper around the NaNoWriMo API which can be found here: [API]("http://nanowrimo.org/wordcount_api", "API"). This SDK also includes the ability to update a user's word count.

Features
========
* Retrieve a user's information (word count, and history)
* Update a user's word count (secret ket required)
* Retrieve the site's word count and history
* Retrieve a region's word count and history, as well as donation information

Examples
========
Retrieving a User
-----------------
```C#
// Retrieve the user
User user = NanoContext.GetUser("Badgerati");

// Display the user's word count and username
Console.WriteLine(string.Format("Word count for {0}: {1}", user.Username, user.WordCount.Count));

// Display the history for a user
foreach (var entry in user.History)
{
    Console.WriteLine(string.Format("Word count on {0}: {1}", entry.Date, entry.Count));
}

// Update a user's word count
user.UpdateCount("some_super_secret_key", 23000);
```

Retrieving a Site
-----------------
```C#
// Retrieve the site stats
Site site = NanoContext.GetSite();

// Display the site's word count
Console.WriteLine(string.Format("Word count for the site: {0}", site.WordCount.Count));

// Display the history for a site
foreach (var entry in site.History)
{
    Console.WriteLine(string.Format("Word count on {0}: {1}", entry.Date, entry.Count));
}
```

Retrieving a Region
-------------------
```C#
// Retrieve the regional stats
Region region = NanoContext.GetRegion("usa-california-east-bay");

// Display the region's word count
Console.WriteLine(string.Format("Word count for {0}: {1}", region.RegionName, region.WordCount.Count));

// Display the history for a region
foreach (var entry in region.History)
{
    Console.WriteLine(string.Format("Word count on {0}: {1}", entry.Date, entry.Count));
}
```