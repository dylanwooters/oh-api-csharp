# oh-api-csharp
oh-api-csharp is a C# wrapper for the [Open Hosting API](http://openhosting.com/api/). It enables you to perform useful actions against the main components of the Open Hosting cloud platform: drives, servers, and resources. Using the library you could, for example, dynamically increase the cpu and memory of a specific server, increase the size of an ssd, or spin up new servers as needed.

The Open Hosting API is itself an implementation of the [ElasticHosts API](http://api-doc.elastichosts.com/). Its documentation is slightly more complete.

Also check out the [Ruby implementation](https://code.seriesdigital.com/lee/openhosting-api-clients/tree/master/oh-api-ruby).

## Usage

1. Obtain your Open Hosting API credentials. They can be found by logging in at [Open Hosting](https://east1.openhosting.com/accounts/login/), clicking on Profile, and then clicking on the Authentication tab.
2. Add your OH credentials to your project's app.config.

   ```
   <add key="OHUserId" value="[your-user-id]" />
   <add key="OHSecretKey" value="[your-secret-key]" />
   ```

3. See the ConsoleTester application for basic usage examples.

## Help Out
oh-api-csharp is a work in progress. I have the drives component complete, and I am current working on [servers](https://github.com/dylanwooters/oh-api-csharp/tree/servers). Feel free to fork the repo and contribute!
