// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Major Code Smell", "S6934:A Route attribute should be added to the controller when a route template is specified at the action level", Justification = "...", Scope = "type", Target = "~T:SportsStore.Controllers.CartController")]
[assembly: SuppressMessage("Major Code Smell", "S4144:Methods should not have identical implementations", Justification = "Doublicate of the code is required", Scope = "member", Target = "~M:SportsStore.Controllers.AdminController.Create(SportsStore.Models.Product)~Microsoft.AspNetCore.Mvc.IActionResult")]
[assembly: SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "...", Scope = "member", Target = "~M:SportsStore.Models.IdentitySeedData.EnsurePopulated(Microsoft.AspNetCore.Builder.IApplicationBuilder)~System.Threading.Tasks.Task")]
[assembly: SuppressMessage("Major Bug", "S4143:Collection elements should not be replaced unconditionally", Justification = "...", Scope = "member", Target = "~M:SportsStore.Infrastructure.PageLinkTagHelper.Process(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext,Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput)")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "...", Scope = "member", Target = "~M:SportsStore.Models.SeedData.EnsurePopulated(Microsoft.AspNetCore.Builder.IApplicationBuilder)")]
[assembly: SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "...", Scope = "member", Target = "~M:SportsStore.Models.SeedData.EnsurePopulated(Microsoft.AspNetCore.Builder.IApplicationBuilder)")]
[assembly: SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "This object should have setter", Scope = "member", Target = "~P:SportsStore.Models.Order.Lines")]
[assembly: SuppressMessage("Major Code Smell", "S2971:LINQ expressions should be simplified", Justification = "Query works well like this", Scope = "member", Target = "~M:SportsStore.Models.Cart.AddItem(SportsStore.Models.Product,System.Int32)")]
[assembly: SuppressMessage("Major Code Smell", "S6964:Value type property used as input in a controller action should be nullable, required or annotated with the JsonRequiredAttribute to avoid under-posting.", Justification = "bool variable can not be null-able in this case as it is meant for the Check block in UI", Scope = "member", Target = "~P:SportsStore.Models.Order.GiftWrap")]
[assembly: SuppressMessage("Major Code Smell", "S6964:Value type property used as input in a controller action should be nullable, required or annotated with the JsonRequiredAttribute to avoid under-posting.", Justification = "id can not be null-able in this case", Scope = "member", Target = "~P:SportsStore.Models.Product.ProductId")]
[assembly: SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "...", Scope = "member", Target = "~M:SportsStore.Models.IdentitySeedData.PopulateIdentityDataAsync(Microsoft.AspNetCore.Builder.IApplicationBuilder)~System.Threading.Tasks.Task")]
