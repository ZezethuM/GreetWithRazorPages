# DEPLOYMENT PROCESS FOR MY GREET APP

# CREATING AN ONLINE SERVER ON DIGITALOCEAN
- Create a Digital ocean accout(which is a cloud hosting provider).
- In Digital ocean I created a droplet(which is a Linux-based virtual machine / a server).

# CONNECTING TO THE SERVER AND ADDING APPLICATION
- Connect to the cloud server on my terminal on my machine using : ssh root@ip_address of server.
- Install necessary applications to run application like Dotnet SDK and git.
- locate the folder for applications or create one using : mkdir <folder name>
- Have a repository of my Application so I can clone it into my server: <git clone repository link>

# RESTORE THE APPLICATION ON THE CURRENT MACHINE USING: 
- dotnet restore
- dotnet build -c Release
- dotnet bin/Release/net6.0/greet.dll --urls=http://localhost:6007/
- Now it is runnin @ zezethu.projectcodex.net, but when I exit the port it will stop so I have to     have it running in the background using nginx.

# RUNNING APPLICATION IN THE BACKGOUND USING NGINX
- use the command : nohup dotnet bin/Release/net6.0/greet.dll --urls=http://localhost:6007/ > vps.log 2>&1 &
- Run it using : zezethu.projectcodex.net.



