# Hudl-Quality-Engineering-Project

A basic Selenium framework for testing the main login page of hudl.com, written in C#/.NET Core 3.1.0.

To run tests:
1. Clone repo 
2. Open solution and add user login credentials to top of LoginTests.cs file
3. Run tests from Visual Studio OR run `dotnet test` from the command line while in the project folder.

I wanted to focus on the essential aspects of logging into a website (successfully logging in, not being able to log in when credentials are invalid, ability to reset a password), but there lots of future tests to add, including:
- Organizational login
- "Remember me" functionality
- Verify that password reset email is sent
- Other links/navigation (Help, Sign up, back arrow to main site, etc.)
