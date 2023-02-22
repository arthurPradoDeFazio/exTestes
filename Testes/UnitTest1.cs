namespace Testes;
using ExTestes;

public class UnitTest1
{
    [Fact]
    public void TestAddValidContact()
    {
        // Arrange
        var contactService = new ExTestes.ContactService();

        // Act
        contactService.AddContact("Arthur", "111111111", "arthur_email@servico.com");

        // Assert
        Assert.True(contactService.contacts.FirstOrDefault(c =>
                                                            c.Name == "Arthur" &&
                                                            c.Phone == "111111111" &&
                                                            c.Email == "arthur_email@servico.com") != null);
    }

    [Fact]
    public void TestAddInvalidContact()
    {
        // Arrange
        var contactService = new ExTestes.ContactService();

        // Act
        Assert.Throws<ArgumentException>(() => contactService.AddContact("111111111", "Arthur", "arthur_email@servico.com"));
    }

    [Fact]
    public void TestListEmptyContact()
    {
        var contactService = new ContactService();

        var resposta = contactService.ListContacts();

        Assert.Equal("Não há contatos cadastrados.", resposta);
    }

    [Fact]
    public void TestListNonEmptyContact()
    {
        var contactService = new ContactService();

        contactService.AddContact("eu", "1", "email1");
        contactService.AddContact("tu", "2", "email2");
        contactService.AddContact("ele", "3", "email3");

        var obtido = contactService.ListContacts();
        var esperado = "Lista de contatos:\n1. eu - 1 - email1\n2. tu - 2 - email2\n3. ele - 3 - email3\n";

        Assert.Equal(esperado, obtido);

    }

    [Fact]
    public void TestUpdateNonExistingContact()
    {
        var contactService = new ContactService();

        var esperado = "Índice inválido. Tente novamente.";
        var obtido1 = contactService.UpdateContact(1, "a", "1", "e");
        _ = contactService.AddContact("a", "1", "e");
        var obtido2 = contactService.UpdateContact(-1, "a", "1", "e");

        Assert.Equal(esperado, obtido1);
        Assert.Equal(esperado, obtido2);
    }

    [Fact]
    public void TestUpdateExistingContact()
    {
        var contactService = new ContactService();

        _ = contactService.AddContact("a", "1", "e");
        var obtido = contactService.UpdateContact(0, "b", "1", "e");
        var esperado = "Contato 'b' atualizado com sucesso.";

        Assert.Equal(esperado, obtido);
        
    }

    [Fact]
    public void TestContactRemovalFromEmptyList()
    {
        var contactService = new ContactService();

        var obtido1 = contactService.RemoveContact(-1);
        var obtido2 = contactService.RemoveContact(0);
        var obtido3 = contactService.RemoveContact(1);
        var esperado = "Índice inválido. Tente novamente.";

        Assert.Equal(esperado, obtido1);
        Assert.Equal(esperado, obtido2);
        Assert.Equal(esperado, obtido3);
    }

    [Fact]
    public void TestContactRemovalFromNonEmptyContact()
    {
        var contactService = new ContactService();

        contactService.AddContact("eu", "1", "email1");
        contactService.AddContact("tu", "2", "email2");
        contactService.AddContact("ele", "3", "email3");

        var invalidoMenosUmObtido = contactService.RemoveContact(-1);
        var invalidoMenosUmEsperado = "Índice inválido. Tente novamente.";

        var invalidoTresObtido = contactService.RemoveContact(-1);
        var invalidoTresEsperado = "Índice inválido. Tente novamente.";

        var removerUmObtido = contactService.RemoveContact(1);
        var removerUmEsperado = "Contato 'tu' removido com sucesso.";

        var removerUmNovamenteObtido = contactService.RemoveContact(1);
        var removerUmNovamenteEsperado = "Contato 'ele' removido com sucesso.";

        Assert.Equal(invalidoMenosUmEsperado, invalidoMenosUmObtido);
        Assert.Equal(invalidoTresEsperado, invalidoTresObtido);
        Assert.Equal(removerUmEsperado, removerUmObtido);
        Assert.Equal(removerUmNovamenteEsperado, removerUmNovamenteObtido);
    }

}
