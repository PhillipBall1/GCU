# Week One

### Class: CST-321
### Professor: Dr. White
### Author: Phillip Ball
### Date: 5 / 15 / 24

---

[UNIX Family of Operating Systems](#unix-family-of-operating-systems)

[Systems & Tools](#systems--tools)

[Activity 1](#activity-1)

## UNIX Family of Operating Systems
[Back to Top](#week-one)

`1. whoami`
`2. users`
`3. ls`

![Alt](docs/familyofOS/1.png)

`4. Change r,w,x permission to a file using chmod`
`5. Check the value of any 3 environment variables`

![Alt](docs/familyofOS/2.png)

`6. Use grep to search for specific content in a file`
`7. Use sort, grep, and piping to find a string in a list of files in a directory`

![Alt](docs/familyofOS/3.png)

`8. Explore the super user account and explain when and how would you use it` 

![Alt](docs/familyofOS/4.png)

>You would use the superuser account for tasks such as installing software, changing system settings, managing users, and editing system files.

`9. Use the Linux/UNIX built-in manual and identify 5 additional, distinct, useful commands. Execute each and capture the results.`

`1. man ls`  
>Lists directory contents.

![Alt](docs/familyofOS/5.png)

`2. man cp`
>Copies files and directories.

![Alt](docs/familyofOS/6.png)

`3. man mv`
>Moves/renames files and directories.

![Alt](docs/familyofOS/7.png)

`4. man ps`
>Displays information about running processes.

![Alt](docs/familyofOS/8.png)

`5. man df`
>Reports file system disk space usage.

![Alt](docs/familyofOS/10.png)

`10. Create a shell script test.sh with 5 different UNIX/Linux commands of your choosing, execute it, and show the results.`

![Alt](docs/familyofOS/11.png)

## Systems & Tools
[Back to Top](#week-one)

`Choose 5 features and explain what (in your opinion) you think happens when you access them.`

**I have never looked into any of these processes, so these are all heavy assumptions**

>**1. Opening Folders:** When I access a list of files from a folder, the storage drive reads and writes from whatever folder I am clicking into, displaying the files to the user. I'm assuming that there is a call to the system that retrieves the list of files existing in that directory.

>**2. Opening Files:** When I access a file, the storage drive reads the data from that file then considers how the file should be open, with how .txt files are usually just text files, I still get 8 different options to choose from when I attempt opening one, so I am assuming that theres some process that considers the file type then gets a call from applications that could manipulate the file type in question. 

>**3. Network Connection:** When I connect to the internet, I believe there is some initial request to the router, which may involve getting my domain name into an IP address, then sending this information to the OS through packets. Then when I connect to a website or a server, The connection from my OS sends information to the website/server containing my IP address. 

>**4. Installing:** When I am installing a software I usually see a windows defender request initially, so I'm assuming that the first thing that happens is a firewall check with the contents and the validity of the files being downloaded. Then files are installed into the directories that may have been specified beforehand. Once the process is complete, there could be a shortcut generated or maybe the software opens immediately. 

>**5. Creating a New User:** When I created my user for windows, I got asked a bunch of different questions such as language, keyboard layout, systems preferences, etc. I believe that it takes in all of that information to set up the initial environment for the user. Each question answered changes settings inside of the OS and I'm assuming that it all is stored within the OS itself. 

![Alt](docs/systems&tools/1.png)

## Activity 1
[Back to Top](#week-one)

`Take a screenshot of the Ubuntu Desktop running in your virtual machine`

>I am using Kali linux with Ubuntu 64x. I was trying to use the Ubuntu ISO but it kept crashing my VM for some reason so I just figured I could do all of the same things within Kali.

![Alt](docs/activity1/1.png)

`Create a new C program that supports the following capabilities`

`1. Variable declarations (you need to research variables, declarations, and data types).`

`2. Getting input from a user (you need to research the scanf() function).`

`3. Operators (you need to research the operators available in C).`

`4. Printing formatted output (you need to research the scanf() function)`

![Alt](docs/activity1/2.png)

`Linux: List Command` `Change Directory` `Make or Remove (Empty) Directory`

![Alt](docs/activity1/3.png)

`Linux: Copy or Move or Remove Files` `Find Files`
`Find Text in Files` `Process`

![Alt](docs/activity1/4.png)

`Windows: Directory Command` `Change Directory` `Make or Remove (Empty) Directory`

![Alt](docs/activity1/5.png)

`Windows: Copy or Move or Remove Files` `Find Files` 
`Find Text in Files` `Process`

![Alt](docs/activity1/6.png)

`Create a bash script that does the following`

`1. Create a text file 'compile.sh' in the text editor`

`2. Indicate the Shell/Script type in line 1: #!/bin/sh`

`3. Enter the required commands to compile and run your Hello World C program`

`4. Give the script permission using: chmod 777 test.sh command and run the script`

![Alt](docs/activity1/7.png)

`Remove the hard code file names and use a bash script argument`

`1. Save the program to compile script that is passed as a script argument in a variable`

`2. Substitute the variable where you currently have the 'HelloWorld' program name text`

![Alt](docs/activity1/8.png)

`Add error checking`

`1. Check that the script arguments are not empty`

`2. Check the return value from 'gcc'`

![Alt](docs/activity1/9.png)

`Working with environment variables`

`1. Create a 'var1.sh' script`

`2. Create a variable in var1.sh script`

`3. Call the printenv command to print the environment variables out`

`4. Call var2.sh from this script`

`5. Create a 'var2.sh' script`

`6. Call the printenv command to print the environment variables out`

`7. Run 'var1.sh' script`

![Alt](docs/activity1/10.png)

`8. Modify 'var1.sh' script and prefix the variable with the word export`

`9. Run 'var1.sh' script again`

`10. What differences do you see in the environment for each script?`

>The 'var=Hello from var1.sh' is exported into the environment variables after including 'export' as a keyword in var1.sh

![Alt](docs/activity1/11.png)