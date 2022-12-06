using LabExcel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LabCalculator
{
    class LabCalculatorVisitor : LabCalculatorBaseVisitor<double>
{
        Dictionary<string, double> tableIdentifier = new Dictionary<string, double>();
        public override double VisitCompileUnit(LabCalculatorParser.CompileUnitContext context)
        {
            return Visit(context.expression());
        }
        public override double VisitNumberExpr(LabCalculatorParser.NumberExprContext context)
        {
            var result = double.Parse(context.GetText());
            Debug.WriteLine(result);
            return result;
        }

        //IdentifierExpr
        public override double VisitIdentifierExpr(LabCalculatorParser.IdentifierExprContext context)
        {
                
            var result = context.GetText();
            double value;

            char columnLetter = result[0];
            int column = (int)columnLetter - 65;

            int row = Int32.Parse(result.Substring(1));

            mainForm form = new mainForm();
            value = (double)(form.dataGridView.Rows[row].Cells[column].Value);

            Debug.WriteLine(value);

            return 0.0;
 //           if (tableIdentifier.TryGetValue(result.ToString(), out value))
 //           {
 //               return value;
 //           }
 //           else
 //           {
 //               return 0.0;
 //           }
        }
        public override double VisitParenthesizedExpr(LabCalculatorParser.ParenthesizedExprContext context)
        {
            return Visit(context.expression());
        }
        public override double VisitExponentialExpr(LabCalculatorParser.ExponentialExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);
            Debug.WriteLine("{0} {1}", left, right);
            return System.Math.Pow(left, right);
        }
        public override double VisitAdditiveExpr(LabCalculatorParser.AdditiveExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);
            if (context.operatorToken.Type == LabCalculatorLexer.ADD)
            {
                Debug.WriteLine("{0} {1}", left, right);
                return left + right;
            }
            else //LabCalculatorLexer.SUBTRACT
            {
                Debug.WriteLine("{0} {1}", left, right);
                return left - right;
            }
        }
        public override double VisitMultiplicativeExpr(LabCalculatorParser.MultiplicativeExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);
            if (context.operatorToken.Type == LabCalculatorLexer.MULTIPLY)
            {
                Debug.WriteLine("{0} {1}", left, right);
                return left * right;
            }
            else if(context.operatorToken.Type == LabCalculatorLexer.DIV)
            {
                if (right == 0)
                {
                    MessageBox.Show("Error!");
                    return 0;
                }
                else
                {
                    Debug.WriteLine("{0} {1}", left, right);
                    return left / right;
                }
            }
            else
            {
                Debug.WriteLine("{0} {1}", left, right);
                return left % right;
            }
        }
        public override double VisitIncExpr(LabCalculatorParser.IncExprContext context)
        {
            var left = WalkLeft(context);
            if (context.operatorToken.Type == LabCalculatorLexer.INC)
            {
                Debug.WriteLine(left);
                return left + 1;
            }
            else //LabCalculatorLexer.SUBTRACT
            {
                Debug.WriteLine(left);
                return left - 1;
            }
        }
        private double WalkLeft(LabCalculatorParser.ExpressionContext context)
        {
            return Visit(context.GetRuleContext<LabCalculatorParser.ExpressionContext>(0));
        }
        private double WalkRight(LabCalculatorParser.ExpressionContext context)
        {
            return Visit(context.GetRuleContext<LabCalculatorParser.ExpressionContext>(1));
        }
    }
}