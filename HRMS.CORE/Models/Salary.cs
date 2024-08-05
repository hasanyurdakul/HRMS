﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.CORE;

public class Salary
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SalaryId { get; set; }
    public int Amount { get; set; }
    [ForeignKey("Employee")]
    public int EmployeeId { get; set; }

    // Navigation properties
    public Employee Employee { get; set; }

}
