using System;
using System.Collections.Generic;
using System.Text;

namespace LoginDemoApp.Entity.Models
{
    public class EmpConstantData
    {
        public static List<EmployeeModel> Users = new List<EmployeeModel>()
        {
            new EmployeeModel()
            {
                EmpId=201, UserName="Renu_Pri",Email = "Renu_Pri@gmail.com",Password="Pri_Renu@123",GivenName="Renu",Surname="Kondapalli",Role="Principal"
            },
            new EmployeeModel()
            {
                EmpId=301, UserName="Vishal_Dev",Email = "Vishal_Dev@gmail.com",Password="Dev_Vish@123",GivenName="Vishal",Surname="Chikane",Role="DEVELOPER"
            },
            new EmployeeModel()
            {
                EmpId=401, UserName="Vaibhav_Ana",Email = "Vaibhav_Ana@gmail.com",Password="Ana_Vaib@123",GivenName="Vaibhav",Surname="Waghole",Role="ANALYST"
            },
            new EmployeeModel()
            {
                EmpId=302, UserName="Akshay_Dev",Email = "Akshay_Dev@gmail.com",Password="Dev_Aksh@123",GivenName="Akshay",Surname="Pawar",Role="DEVELOPER"
            },
            new EmployeeModel()
            {
                EmpId=303, UserName="Aniket_Dev",Email = "Aniket_Dev@gmail.com",Password="Dev_Anik@123",GivenName="Aniket",Surname="Chakrod",Role="DEVELOPER"
            },
            new EmployeeModel()
            {
                EmpId=304, UserName="Shubham_Dev",Email = "Shubham_Dev@gmail.com",Password="Dev_Shub@123",GivenName="Shubham",Surname="Wasule",Role="DEVELOPER"
            },
            new EmployeeModel()
            {
                EmpId=402, UserName="Rushikesh_Ana",Email = "Rushikesh_Ana@gmail.com",Password="Ana_Rush@123",GivenName="Rushikesh",Surname="Patil",Role="ANALYST"
            },
            new EmployeeModel()
            {
                EmpId=305, UserName="Purnima_Dev",Email = "Purnima_Dev@gmail.com",Password="Dev_Purn@123",GivenName="Purnima",Surname="Pandey",Role="DEVELOPER"
            },
            new EmployeeModel()
            {
                EmpId=406, UserName="Pranali_Dev",Email = "Pranali_Dev@gmail.com",Password="Dev_Pran@123",GivenName="Pranali",Surname="Bejelwar",Role="DEVELOPER"
            },
            
            new EmployeeModel()
            {
                EmpId=501, UserName="Mayur_JE",Email = "Mayur_JE@gmail.com",Password="JE_Mayu@123",GivenName="Mayur",Surname="Kharad",Role="JE"
            },

        };

    }
}
