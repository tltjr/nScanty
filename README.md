nScanty
=====

Overview
----------

nScanty is an extremely lightweight ASP.net MVC 3 blogging platform, based on the Sinatra based blog, [Scanty](https://github.com/adamwiggins/scanty).

nScanty should be fully usable, but is not fully tested and therefore should still be considered beta software at best.

nScanty is designed to work with [MongoDb](http://www.mongodb.org/), but could easily be modified to work with other dbs.

Getting Started
-----------------

After forking and cloning the project, look in the appSettings of web.config and change the title, author, etc.. to fit your needs. Don't forget to set a username and password, they will be required for all administrative functions.

To run the application locally. There is a appSetting called "env", which, when given a value of "local", will attempt to use your local MongoDb instance. Instruction for installation can be found here: [http://docs.mongodb.org/manual/tutorial/install-mongodb-on-windows/](http://docs.mongodb.org/manual/tutorial/install-mongodb-on-windows/)

The blog can also easily be used with AppHarbor and AppHarbor's MongoLab add-on. To use MongoLab, simply replace the local connection string with:  

`var connection = ConfigurationManager.AppSettings.Get("MONGOLAB_URI");`

and enable the add-on within AppHarbor. Upon deploy you'll be fully up and running.  

Administration
----------------
There is NO direct link to login. Navigate to http://{base url}/Account/LogOn to sign in and enable administrative functions like adding, editing and deleting posts. I recommend bookmarking the login screen as there is no obvious way to get back to it!

Once signed in, a "New Post" link appears in the upper right hand corner. Clicking on an existing post provides an edit link where posts can be updated or deleted.


Help
-----
Feel free to add an issue if you encounter a specific problem/bug.

Stay tuned for updates, hopefully I'll have a more production worthy version available soon.
