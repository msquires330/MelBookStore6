using MelBookStore.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MelBookStore.Models
{
    public class SessionCart : Cart 
    {
            public static Cart GetCart(IServiceProvider services)
            {
                ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;
                SessionCart cart = session?.GetJson<SessionCart>("cart")
                ?? new SessionCart();
                cart.Session = session;
                return cart;
            }
            [JsonIgnore]
            public ISession Session { get; set; }
            public override void AddItem(Project project, int quantity)
            {
                base.AddItem(project, quantity);
                Session.SetJson("cart", this);
            }

            public override void RemoveLine(Project project)
            {
                base.RemoveLine(project);
                Session.SetJson("cart", this);
            }
            public override void Clear()
            {
                base.Clear();
                Session.Remove("cart");
            }
        }
    }
