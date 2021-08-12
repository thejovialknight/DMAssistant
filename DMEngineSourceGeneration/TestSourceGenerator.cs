using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMEngineSourceGeneration
{
    [Generator]
    public class TestSourceGenerator : ISourceGenerator
    {
        public const string attributeText = @"
using System;
namespace DMEngine.Database
{
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    sealed class LinkDataAttribute : Attribute
    {
        public LinkDataAttribute()
        {
        }
        public string PropertyName { get; set; }
    }
}
";

        public void Initialize(GeneratorInitializationContext context)
        {
            // Register a factory that can create our custom syntax receiver
            context.RegisterForSyntaxNotifications(() => new MySyntaxReceiver());
        }

        public void Execute(GeneratorExecutionContext context)
        {
            context.AddSource("LinkedDataAttribute", attributeText);

            if (!(context.SyntaxReceiver is ISyntaxReceiver reciever))
                return;


        }

        // Has to check whether it implements the interface perhaps?
        class MySyntaxReceiver : ISyntaxReceiver
        {
            public List<FieldDeclarationSyntax> CandidateFields { get; } = new List<FieldDeclarationSyntax>();

            public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
            {
                if(syntaxNode is FieldDeclarationSyntax fieldDeclarationSyntax
                    && fieldDeclarationSyntax.AttributeLists.Count > 0)
                {
                    CandidateFields.Add(fieldDeclarationSyntax);
                }
            }
        }
    }
}

// using System; BEING AT BEGINING OF TEXT

namespace DMEngine.Database
{
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    sealed class LinkDataAttribute : Attribute
    {
        public LinkDataAttribute()
        {

        }

        public string PropertyName { get; set; }
    }
}