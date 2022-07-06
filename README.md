# Basic User System (ASP.NET Core MVC)

# • Link: https://hani-asp-net.herokuapp.com/

My first ASP.NET Core project, its a user system app with some features, using the same idea as my one of my previous projects: [User System](https://github.com/Hani-ALHamad/react-node-user-system).  
I wanted this project to be as exact the same as my previous UserSystem project, but since [ASP.NET Core's Identity](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-6.0&tabs=visual-studio) does offer many functionalities, i have decided to keep some of them in this app.

***• Features:*** 
- Signing up a new account, it does tell if username is already taken or not.   
- Logging to an existing account.   
- The ability to upload an avatar to the database, the ability to remove it too (avatars are stored as binary data).   
- The ability to change the password for your existing account.   
- The ability to change your username.   
- The ability to download your account data.   
- The ability to delete your account.   
- Logging out from your account.   
- All data are stored in a MS SQL Server database.  

**All features above are using ASP.NET Core's Identity except of the avatar part, i made it manually.*   

**I made multiple changes to the Identity as well, like switching everything from using Email into using Username, i have disabled many things in the Identity too.*

---
Sign Up page:   
![alt text](https://raw.githubusercontent.com/Hani-ALHamad/asp.net-core-user-system/master/images/register.jpg)

Log in page:   
![alt text](https://raw.githubusercontent.com/Hani-ALHamad/asp.net-core-user-system/master/images/login.jpg)

Home page:   
![alt text](https://raw.githubusercontent.com/Hani-ALHamad/asp.net-core-user-system/master/images/home.jpg)

Adding avatar:   
![alt text](https://raw.githubusercontent.com/Hani-ALHamad/asp.net-core-user-system/master/images/profile1.jpg)
![alt text](https://raw.githubusercontent.com/Hani-ALHamad/asp.net-core-user-system/master/images/profile2.jpg)

Changing Username:   
![alt text](https://raw.githubusercontent.com/Hani-ALHamad/asp.net-core-user-system/master/images/username.jpg)

Changing Password:   
![alt text](https://raw.githubusercontent.com/Hani-ALHamad/asp.net-core-user-system/master/images/password.jpg)

Download your data/ delete your account:   
![alt text](https://raw.githubusercontent.com/Hani-ALHamad/asp.net-core-user-system/master/images/data.jpg)

the database:   
![alt text](https://raw.githubusercontent.com/Hani-ALHamad/asp.net-core-user-system/master/images/db.jpg)

AspNetUsers (Identity table):   
![alt text](https://raw.githubusercontent.com/Hani-ALHamad/asp.net-core-user-system/master/images/userstabledesign.jpg)
![alt text](https://raw.githubusercontent.com/Hani-ALHamad/asp.net-core-user-system/master/images/userstabledata.jpg)

UserAvatar table:   
![alt text](https://raw.githubusercontent.com/Hani-ALHamad/asp.net-core-user-system/master/images/avatarstabledesign.jpg)
![alt text](https://raw.githubusercontent.com/Hani-ALHamad/asp.net-core-user-system/master/images/avatarstabledata.jpg)
