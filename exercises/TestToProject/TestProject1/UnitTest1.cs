using NUnit.Framework;
using System;
using System.Collections.Generic;
using TestToProject;

[TestFixture]
public class EmailTest
{
    [Test]
    public void EmailConstructorSetsVariables()
    {
        var testEmail = new Email("sender", "receiver", "message", 5);
        Assert.That(testEmail.Sender, Is.EqualTo("sender"));
        Assert.That(testEmail.Receiver, Is.EqualTo("receiver"));
        Assert.That(testEmail.Message, Is.EqualTo("message"));
        Assert.That(testEmail.Priority, Is.EqualTo(5));
    }
    
    [Test]
    public void EmailSentStartsFalse()
    {
        var testEmail = new Email("sender", "receiver", "message", 5);
        Assert.That(testEmail.Sent, Is.False);
    }
    
    [Test]
    public void EmailAccountHasStaticDictionaryAccounts()
    {
        Assert.That(MailAccount.accounts, Is.TypeOf<Dictionary<string, MailAccount>>());
        Assert.That(MailAccount.accounts, Is.Not.Null);
    }
    
    [Test]
    public void EmailSendIsCallable()
    {
        var testEmail = new Email("sender", "receiver", "message", 5);
        MailAccount.accounts["receiver"] = new MailAccount();
        Assume.That(testEmail.Sent, Is.False);
        Assert.That(testEmail.Send, Throws.Nothing);
    }
    
    [Test]
    public void EmailSendCannotBeCalledIfAlreadySent()
    {
        var testEmail = new Email("sender", "receiver", "message", 5);
        MailAccount.accounts["receiver"] = new MailAccount();
        Assume.That(testEmail.Sent, Is.False);
        Assume.That(testEmail.Send, Throws.Nothing);
        Assert.That(testEmail.Send(), Is.False);
    }
    
    [Test]
    public void EmailAccountGetInboxReturnsArrayOfEmails()
    {
        var testEmail = new Email("sender", "receiver", "message", 5);
        MailAccount.accounts["receiver"] = new MailAccount();
        Assume.That(testEmail.Sent, Is.False);
        Assume.That(testEmail.Send(), Is.True);
        Email[] array = MailAccount.accounts["receiver"].GetInbox();
        Assert.That(array[0].Message, Is.EqualTo("message"));
    }
}