# oh-api-csharp
OHAPICSharp is a C# wrapper for the [Open Hosting API](http://openhosting.com/api/). It is a work in progress. Currently I have the drive service implemented, which gives users easy access to the drives in their accounts. Next up are servers and resources.

The Open Hosting API is itself an implementation of the [ElasticStack API](http://api-doc.elastichosts.com/). Its documentation is slightly more complete.

Also check out the [Ruby implementation](https://code.seriesdigital.com/lee/openhosting-api-clients/tree/master/oh-api-ruby).

## Usage

1. Obtain your Open Hosting API credentials. They can be found by logging in at [Open Hosting](https://east1.openhosting.com/accounts/login/), clicking on Profile, and then clicking on the Authentication tab.
2. Add your OH credentials to your projects app.config.

   ```
   <add key="OHUserId" value="[your-user-id]" />
   <add key="OHSecretKey" value="[your-secret-key]" />
   ```

3. See the ConsoleTester application for basic usage examples.
