nScanty
=====

Overview
----------

nScanty is an extremely lightweight ASP.net MVC 3 blogging platform, based on the Sinatra based blog, [Scanty](https://github.com/adamwiggins/scanty).

nScanty should be fully usable, but is not fully tested and therefore should still be considered beta software at best.

nScanty is designed to work with [MongoDb](http://www.mongodb.org/) and [AppHarbor](https://appharbor.com/), but could easily be modified to work with other databases and/or hosting providers.

Getting Started
-----------------

After forking and cloning the project, look in the appSettings of web.config and change the title, author, etc.. to fit your needs. Don't forget to set a username and password, they will be required for all administrative functions. If you would prefer not to enter a plain text password, there is file called HashedPasswordGenerator.cs in the root of the project which you can use to hash your password. Hashed passwords should be place in the "hashedPassword" portion of the web.config. If a hashed password is present, the password setting will be ignored. If no hash password exists, the password setting will be used.

To run the application locally. There is a appSetting called "env", which, when given a value of "local", will attempt to use your local MongoDb instance. Instruction for installation can be found here: [http://docs.mongodb.org/manual/tutorial/install-mongodb-on-windows/](http://docs.mongodb.org/manual/tutorial/install-mongodb-on-windows/)

nScanty's default configuration is designed to work seamlessly with AppHarbor.
In fact, after modifying the appSettings above, and creating an AppHarbor
application with the MongoLab add-on enabled, nScanty should work on AppHarbor
without any further modification. Note that the "env" appSetting should NOT be set to "local" when deploying to appHarbor (it can be empty or "prod" for example).

Administration
----------------
There is NO direct link to login. Navigate to http://{base url}/Account/LogOn to sign in and enable administrative functions like adding, editing and deleting posts. I recommend bookmarking the login screen as there is no obvious way to get back to it!

Once signed in, a "New Post" link appears in the upper right hand corner. Clicking on an existing post provides an edit link where posts can be updated or deleted.


Help
-----
Feel free to add an issue if you encounter a specific problem/bug.

Stay tuned for updates, hopefully I'll have a more production worthy version available soon.
