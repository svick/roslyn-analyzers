// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Composition;
using System.Runtime.Analyzers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace System.Runtime.CSharp.Analyzers
{
    /// <summary>
    /// CA2242: Test for NaN correctly
    /// </summary>
    [ExportCodeFixProvider(LanguageNames.CSharp), Shared]
    public class CSharpTestForNaNCorrectlyFixer : TestForNaNCorrectlyFixer
    {
        protected override SyntaxNode GetBinaryExpression(SyntaxNode node)
        {
            var argumentSyntax = node as ArgumentSyntax;
            return argumentSyntax != null ? argumentSyntax.Expression : node;
        }

        protected override bool IsEqualsOperator(SyntaxNode node)
        {
            return node.IsKind(SyntaxKind.EqualsExpression);
        }

        protected override bool IsNotEqualsOperator(SyntaxNode node)
        {
            return node.IsKind(SyntaxKind.NotEqualsExpression);
        }

        protected override SyntaxNode GetLeftOperand(SyntaxNode binaryExpressionSyntax)
        {
            return ((BinaryExpressionSyntax)binaryExpressionSyntax).Left;
        }

        protected override SyntaxNode GetRightOperand(SyntaxNode binaryExpressionSyntax)
        {
            return ((BinaryExpressionSyntax)binaryExpressionSyntax).Right;
        }
    }
}
