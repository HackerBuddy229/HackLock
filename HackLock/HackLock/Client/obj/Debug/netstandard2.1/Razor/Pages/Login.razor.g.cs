#pragma checksum "/home/hackerbuddy/repos/HackLock/HackLock/HackLock/Client/Pages/Login.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b82ae181cdbf56f7588c2e4aaf52e94c9d2fcc81"
// <auto-generated/>
#pragma warning disable 1591
namespace HackLock.Client.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "/home/hackerbuddy/repos/HackLock/HackLock/HackLock/Client/_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/home/hackerbuddy/repos/HackLock/HackLock/HackLock/Client/_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/home/hackerbuddy/repos/HackLock/HackLock/HackLock/Client/_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/home/hackerbuddy/repos/HackLock/HackLock/HackLock/Client/_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/home/hackerbuddy/repos/HackLock/HackLock/HackLock/Client/_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/home/hackerbuddy/repos/HackLock/HackLock/HackLock/Client/_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "/home/hackerbuddy/repos/HackLock/HackLock/HackLock/Client/_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "/home/hackerbuddy/repos/HackLock/HackLock/HackLock/Client/_Imports.razor"
using HackLock.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "/home/hackerbuddy/repos/HackLock/HackLock/HackLock/Client/_Imports.razor"
using HackLock.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "/home/hackerbuddy/repos/HackLock/HackLock/HackLock/Client/_Imports.razor"
using HackLock.Client.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "/home/hackerbuddy/repos/HackLock/HackLock/HackLock/Client/Pages/Login.razor"
using System.Diagnostics;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/home/hackerbuddy/repos/HackLock/HackLock/HackLock/Client/Pages/Login.razor"
using System.Threading;

#line default
#line hidden
#nullable disable
    public partial class Login : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "form");
            __builder.AddMarkupContent(2, "\n    ");
            __builder.OpenElement(3, "input");
            __builder.AddAttribute(4, "type", "text");
            __builder.AddAttribute(5, "placeholder", "UserName");
            __builder.AddAttribute(6, "class", "form-item");
            __builder.AddAttribute(7, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 6 "/home/hackerbuddy/repos/HackLock/HackLock/HackLock/Client/Pages/Login.razor"
                                                                       _username

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(8, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => _username = __value, _username));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.AddMarkupContent(9, "\n    ");
            __builder.OpenElement(10, "input");
            __builder.AddAttribute(11, "type", "password");
            __builder.AddAttribute(12, "placeholder", "Password");
            __builder.AddAttribute(13, "class", "form-item");
            __builder.AddAttribute(14, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 7 "/home/hackerbuddy/repos/HackLock/HackLock/HackLock/Client/Pages/Login.razor"
                                                                           _password

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(15, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => _password = __value, _password));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.AddMarkupContent(16, "\n    ");
            __builder.OpenElement(17, "button");
            __builder.AddAttribute(18, "class", "btn" + " btn-primary" + " " + (
#nullable restore
#line 8 "/home/hackerbuddy/repos/HackLock/HackLock/HackLock/Client/Pages/Login.razor"
                                    _buttonStyle

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(19, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 9 "/home/hackerbuddy/repos/HackLock/HackLock/HackLock/Client/Pages/Login.razor"
              TryUnlock

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(20, "\n    Unlock");
            __builder.CloseElement();
            __builder.AddMarkupContent(21, "\n");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 13 "/home/hackerbuddy/repos/HackLock/HackLock/HackLock/Client/Pages/Login.razor"
       
    private string _username = string.Empty;
    private string _password = String.Empty;
    private bool _awaitingUnlock = false;
    private string _buttonStyle;


    private void ToggleButtonAwaitState() {
        _awaitingUnlock = !_awaitingUnlock;
        _buttonStyle = _awaitingUnlock ? "AwaitingButton" : "";  
    }
    

    [Parameter]
    public EventCallback UnlockCallback { get; set; }

    private async void TryUnlock(MouseEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(_username) || string.IsNullOrWhiteSpace(_password))
            return;

            ToggleButtonAwaitState();
        if (await UnlockService.Unlock(_username, _password)) {
            ToggleButtonAwaitState();
            await UnlockCallback.InvokeAsync(null);
        } else
            ToggleButtonAwaitState();
        
            
    }



#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private UnlockService UnlockService { get; set; }
    }
}
#pragma warning restore 1591
