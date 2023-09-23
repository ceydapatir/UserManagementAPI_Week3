# UserManagementAPI_Week3
A RestFul API that provides HTTP requests for user data. User data validation processes were carried out using the Fluent Validation library. By creating ViewModel and DTO structures, responses have been made more readable and the user has been able to avoid unnecessary operations.


## Installation
Clone this repo and run these commands in the project file directory:
```
dotnet build
dotnet run
```


## Requests
* GET   /api/Users: This request throws an error if there is no user in the database, otherwise it returns user data.
* GET   /api/Users/{id}: This request returns the user data with the received id in the database, and if there is no such user, it throws an error.
* POST  /api/Users: This request creates a new user if there is no user with the same citizen id in the database, otherwise it throws an error.
* PUT   /api/Users/{id}: This request updates the user data with the received id in the database, and if there is no such user, it throws an error.
* DELETE   /api/Users/{id}: This request deletes the user data with the received id in the database, and if there is no such user, it throws an error.


## Mapping
The models were mapped to appropriate versions as follows.
```c#
public MapperProfile(){
            CreateMap<User, UserViewModel>()           // Map for GET request
                .ForMember(i => i.Status, opt => opt.MapFrom(src => ((UserStatusEnum)src.StatusID).ToString()))
                .ForMember(i => i.BirthDate, opt => opt.MapFrom(src => src.BirthDate.Date.ToString("dd/MM/yyy")));
            CreateMap<UserDTO, User>();               // Map for POST request
            CreateMap<UserDTO, User>().ReverseMap();  // Map fot PUT request
        }
```


##Fluent Validation
Below is the Fluent Validation process performed for the POST request.
* Validation limits set in CreateUserValidation.cs
```c#
public CreateUserValidator(){
            RuleFor(i => i.Model.Name).NotNull().MaximumLength(20);
            RuleFor(i => i.Model.Surname).NotNull().MaximumLength(20);
            RuleFor(i => i.Model.CitizenNum).NotNull().Length(11);
            RuleFor(i => i.Model.BirthDate).NotEmpty().LessThanOrEqualTo(DateTime.Now.Date.AddYears(-18));
            RuleFor(i => i.Model.Mail).NotNull();
            RuleFor(i => i.Model.Phone).NotEmpty().GreaterThan(0);
        }
```

* Validation performed in UsersController.cs
```c#
CreateUserValidator validator = new CreateUserValidator();
validator.ValidateAndThrow(command);
```


## Models
* User
```
User
    {
        UserId        integer
        Name          string
        Surname       string
        CitizenNum    string
        BirthDate     string($date-time)
        Mail          string
        Phone         integer
        StatusId      integer
    }
```
* UserDTO
```
UserDTO
    {
        Name          string
        Surname       string
        CitizenNum    string
        BirthDate     string($date-time)
        Mail          string
        Phone         integer
        StatusId      integer
    }
```
* UserViewModel
```
UserViewModel
    {
        UserId        integer
        Name          string
        Surname       string
        CitizenNum    string
        BirthDate     string
        Mail          string
        Phone         integer
        Status        string
    }
```
