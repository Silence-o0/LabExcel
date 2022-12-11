using LabExcel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LabCalculator
{
    class LabCalculatorVisitor : LabCalculatorBaseVisitor<double>
    {
        public override double VisitCompileUnit(LabCalculatorParser.CompileUnitContext context)
        {
            return Visit(context.expression());
        }
        public override double VisitNumberExpr(LabCalculatorParser.NumberExprContext context)
        {
            var result = double.Parse(context.GetText());
            Debug.WriteLine(result);

            Data.CorrectCalculate = true;
            return result;
        }
        public override double VisitIdentifierExpr(LabCalculatorParser.IdentifierExprContext context)
        {
            var result = context.GetText();
            double value = 0.0;


            Data.currentCell.CellsInFormula.Add(result.ToString());

            var resultCell = (from list in Data.cellsList
                           from cell in list
                           where cell.Name == result
                           select cell).FirstOrDefault();

            if (resultCell.Value == null)
            {
                value = 0;
            }
            else
            {
                value = double.Parse(resultCell.Value);
            }

            Data.CorrectCalculate = true;
            return value;
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
            Data.CorrectCalculate = true;
            return Math.Pow(left, right);
        }
        public override double VisitAdditiveExpr(LabCalculatorParser.AdditiveExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);
            if (context.operatorToken.Type == LabCalculatorLexer.ADD)
            {
                Debug.WriteLine("{0} {1}", left, right);
                Data.CorrectCalculate = true;
                return left + right;
            }
            else 
            {
                Debug.WriteLine("{0} {1}", left, right);
                Data.CorrectCalculate = true;
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
                Data.CorrectCalculate = true;
                return left * right;
            }
            else if (context.operatorToken.Type == LabCalculatorLexer.DIV)
            {
                if (right == 0)
                {
                    MessageBox.Show("На 0 ділити не можна.");
                    Data.CorrectCalculate = false;
                    return 0;
                }
                else
                {
                    Debug.WriteLine("{0} {1}", left, right);
                    Data.CorrectCalculate = true;
                    return left / right;
                }
            }
            else
            {
                if (right == 0)
                {
                    MessageBox.Show("На 0 ділити не можна.");
                    Data.CorrectCalculate = false;
                    return 0;
                }
                else
                {
                    Debug.WriteLine("{0} {1}", left, right);
                    Data.CorrectCalculate = true;
                    return left % right;
                }
            }

        }
        public override double VisitIncExpr(LabCalculatorParser.IncExprContext context)
        {
            var left = WalkLeft(context);
            if (context.operatorToken.Type == LabCalculatorLexer.INC)
            {
                Debug.WriteLine(left);
                Data.CorrectCalculate = true;
                return left + 1;
            }
            else 
            {
                Debug.WriteLine(left);
                Data.CorrectCalculate = true;
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