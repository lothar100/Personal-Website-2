# Personal-Website
This is the code for my personal portfolio website. It's now in the cloud, check it out!
The website is a .NET6 application built with Blazor WebAssembly.
The frontend is staticly hosted in AWS S3 and the backend is hosted on AWS Lambda.

### Frontend Deployment
1. dotnet publish -c Release
2. cd .\bin\Release\net6.0\publish\wwwroot\
3. aws s3 sync ./ s3://pietrlangevoort.cloud/ --delete

### Backend Deployment
1. dotnet lambda deploy-serverless
2. enable function URL if needed