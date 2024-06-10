using System;
using Microsoft.AspNetCore.Identity;

namespace TodoApp.Core.Entities;

// This is our TodoUser, we can modify this if we need
// to add custom properties to the user
public class TodoUser : IdentityUser { }