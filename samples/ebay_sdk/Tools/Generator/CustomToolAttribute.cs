#region Copyright
//	Copyright (c) 2008 eBay, Inc.
//
//	This program is licensed under the terms of the eBay Common Development and 
//	Distribution License (CDDL) Version 1.0 (the "License") and any subsequent 
//	version thereof released by eBay.  The then-current version of the License 
//	can be found at https://www.codebase.ebay.com/Licenses.html and in the 
//	eBaySDKLicense file that is under the eBay SDK install directory.
#endregion
namespace eBay.WebService.CodeGenerator
{
  using System;
  using System.Runtime.InteropServices;

  /// <summary>
  /// 
  /// </summary>
  [AttributeUsage(AttributeTargets.Class, AllowMultiple=false)]
  public class CustomToolAttribute: Attribute
  {

    /// <summary></summary>
    protected string _name;

    /// <summary></summary>
    protected string _description;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    public CustomToolAttribute(string name):
      this(name, "")
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="description"></param>
    public CustomToolAttribute(string name, string description)
    {
      this._name = name;
      this._description = description;
    }

    /// <summary>
    /// 
    /// </summary>
    public string Name
    {
      get
      {
        return this._name;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    public string Description
    {
      get
      {
        return this._description;
      }
    }

  }
}
