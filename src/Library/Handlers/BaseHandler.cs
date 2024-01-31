using System;
using System.Linq;
using Telegram.Bot.Types;

namespace Library
{
    // genera herencia y delegacion
    public abstract class BaseHandler : IHandler
    {
        public IHandler Next { get; set; }

        public string[] Keywords { get; set; }

        public BaseHandler(IHandler next)
        {
            this.Next = next;
        }

        public BaseHandler(string[] keywords, BaseHandler next)
        {
            this.Keywords = keywords;
            this.Next = next;
        }

        protected abstract void InternalHandle(Message message, out string response);

        protected virtual void InternalCancel(Message message)
        {
            // Intencionalmente en blanco.
        }

        protected virtual bool CanHandle(Message message)
        {
            // Cuando no hay palabras clave este método debe ser sobreescrito por las clases sucesoras y por lo tanto
            // este método no debería haberse invocado.
            if (this.Keywords == null || this.Keywords.Length == 0)
            {
                throw new InvalidOperationException("No hay palabras clave que puedan ser procesadas");
            }

            return this.Keywords.Any(s => message.Text.StartsWith(s, StringComparison.InvariantCultureIgnoreCase));
        }

        public IHandler Handle(Message message, out string response)
        {
            if (this.CanHandle(message))
            {
                this.InternalHandle(message, out response);
                return this;
            }
            else if (this.Next != null)
            {
                return this.Next.Handle(message, out response);
            }
            else
            {
                response = String.Empty;
                return null;
            }
        }

        public virtual void Cancel(Message message)
        {
            this.InternalCancel(message);
            if (this.Next != null)
            {
                this.Next.Cancel(message);
            }
        }
    }
}