using System;
namespace ExTestes
{
    public class ContactService
    {
        public List<Contact> contacts = new List<Contact>();

        public bool AddContact(string name, string phone, string email)
        {
            var contact = new Contact(name, phone, email);
            contacts.Add(contact);

            return true;
        }

        public string ListContacts()
        {
            if (contacts.Count == 0)
            {
                return "Não há contatos cadastrados.";
            }

            var contatos = "Lista de contatos:\n";

            for (int i = 0; i < contacts.Count; i++)
            {
                var contact = contacts[i];
                contatos += $"{i + 1}. {contact.Name} - {contact.Phone} - {contact.Email}\n";
            }

            return contatos;
        }

        public string UpdateContact(int index, string name, string phone, string email)
        {
            if (index < 0 || index >= contacts.Count)
            {
                return "Índice inválido. Tente novamente.";
            }

            var contact = contacts[index];

            contact.Name = name;
            contact.Phone = phone;
            contact.Email = email;

            return $"Contato '{name}' atualizado com sucesso.";
        }

        public string RemoveContact(int index)
        {
            if (index < 0 || index >= contacts.Count)
            {
                return "Índice inválido. Tente novamente.";
            }

            var contact = contacts[index];
            contacts.Remove(contact);

            return $"Contato '{contact.Name}' removido com sucesso.";
        }
    }
}

