# Habits : Build wellness habits daily
## @SoftbinatorLabs2023 .NET

![](https://github.com/IoanaLivia/Habits_App/blob/master/Assets/Images/Habits_README_1.png)
![](https://github.com/IoanaLivia/Habits_App/blob/master/Assets/Images/Habits_README_2.png)

## Theme : Smart Living 

In order to meet theme requirements, I decided to develop a wellness app that enables users to set habits they want to build, keep track of them & earn badges along the way. The project aims to use Gamification techniques in order to cultivate and maintain motivation by providing badges. The habits that are provided are divided into categories such as Environment, Learning, Health, Fitness and Spirituality. The Habits app not only focuses on inner growth, but on outer growth as well, especially in relation to concerns such as Climate Change, by encouraging users to pursue habits such as: Recycle paper, Recycle glass, Use public transport.

## [Presentation](https://www.canva.com/design/DAFe5s7nvkQ/8-o_j1ZZHzKOuABO4Mj5Cg/edit?utm_content=DAFe5s7nvkQ&utm_campaign=designshare&utm_medium=link2&utm_source=sharebutton)

## Requirements

* Source code pe GIT

* Basic OOP / .NET

* Swagger / Middlewares (and utils)

* Auth/Register (Identity/JWT/Identity Server/ Oauth)

* Net + Sql Server/Mysql

* WEB Basics REST (.NET Web Api)

* Config BestPractices (Dependency Injection, Loggers, baseClasses,etc.)

* LINQ

## Extras

* Upload/read blobs

* Email/SMTP

* Webjob

## Diagram

![](https://github.com/IoanaLivia/Habits_App/blob/master/Assets/Images/Diagram/HabitsDiagram.png)

## Application Flow : User

The user registers and is automatically assigned the BasicUser role (using Register in AuthController). The user is able to view the habits (name & categories). 
The user can search a habit by name. He can assign himself a habit. [In progress] The user can also view available badges and linked habits. T
he user can update and delete his profile or account (profile + user account).

## Application Flow : Admin

The admin can create both admin accounts (RegisterAdmin) and user accounts (Register). The Admin has additional CRUD operations in the controller and
higher priviledges.

## Architecture

### DDD: Domain-Driven-Design

* Api

* Application

* Domain

* Infrastructure

## Development

.NET 6
