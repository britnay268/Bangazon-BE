﻿using System;
namespace Bangazon_BE.Models;

public class Users
{
	public int Id { get; set; }
	public string? Name { get; set; }
	public string Username { get; set; }
    public string? Email { get; set; }
    public string Uid { get; set; }
	public bool Seller { get; set; }
	public List<Products>? Products { get; set; }
	public List<Orders>? Order { get; set; }
}

