using System;
using System.Collections.Generic;
using System.Linq;
using MathParser.Exceptions;

namespace MathParser
{
    public class Parser
    {
        private readonly Queue<NumberClass> _outputQueue;
        private readonly Stack<string> _operatorStack;
        private readonly Dictionary<string, NumberClass> _variables;
        private readonly List<FunctionClass> _functions;
        private readonly Dictionary<string, Delegate> _customFunctions;

        /// <summary>
        /// 
        /// </summary>
        public enum RoundingMethods
        {
            Round,
            RoundUp,
            RoundDown,
            Truncate
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Parser"/> class.
        /// </summary>
        public Parser()
        {
            _outputQueue = new Queue<NumberClass>();
            _operatorStack = new Stack<string>();
            _variables = new Dictionary<string, NumberClass>();
            _functions = new List<FunctionClass>();
            _customFunctions = new Dictionary<string, Delegate>();
        }

        /// <summary>
        /// Unregisters the custom function.
        /// </summary>
        /// <param name="functionName">Name of the function.</param>
        /// <exception cref="MathParser.Exceptions.NoSuchFunctionException"></exception>
        public void UnregisterCustomFunction(string functionName)
        {
            try
            {
                _customFunctions.Remove(functionName);
            }
            catch (Exception)
            {
                throw new NoSuchFunctionException();
            }
        }

        /// <summary>
        /// Unregisters all custom functions.
        /// </summary>
        public void UnregisterAllCustomFunctions()
        {
            _customFunctions.Clear();
        }

        /// <summary>
        /// Registers the custom function.
        /// </summary>
        /// <param name="functionName">Name of the function.</param>
        /// <param name="method">The method.</param>
        public void RegisterCustomFunction(string functionName, Func<object, object> method)
        {
            _customFunctions.Add(functionName, method);
        }

        /// <summary>
        /// Registers the custom function.
        /// </summary>
        /// <param name="functionName">Name of the function.</param>
        /// <param name="method">The method.</param>
        public void RegisterCustomFunction(string functionName, Func<object, object, object> method)
        {
            _customFunctions.Add(functionName, method);
        }

        /// <summary>
        /// Registers the custom function.
        /// </summary>
        /// <param name="functionName">Name of the function.</param>
        /// <param name="method">The method.</param>
        public void RegisterCustomFunction(string functionName, Func<object, object, object, object> method)
        {
            _customFunctions.Add(functionName, method);
        }

        /// <summary>
        /// Registers the custom function.
        /// </summary>
        /// <param name="functionName">Name of the function.</param>
        /// <param name="method">The method.</param>
        public void RegisterCustomFunction(string functionName, Func<object, object, object, object, object> method)
        {
            _customFunctions.Add(functionName, method);
        }

        /// <summary>
        /// Registers the custom integer function.
        /// </summary>
        /// <param name="functionName">Name of the function.</param>
        /// <param name="method">The method.</param>
        public void RegisterCustomIntegerFunction(string functionName, Func<int, int> method)
        {
            _customFunctions.Add(functionName, method);
        }

        /// <summary>
        /// Registers the custom integer function.
        /// </summary>
        /// <param name="functionName">Name of the function.</param>
        /// <param name="method">The method.</param>
        public void RegisterCustomIntegerFunction(string functionName, Func<int, int, int> method)
        {
            _customFunctions.Add(functionName, method);
        }

        /// <summary>
        /// Registers the custom integer function.
        /// </summary>
        /// <param name="functionName">Name of the function.</param>
        /// <param name="method">The method.</param>
        public void RegisterCustomIntegerFunction(string functionName, Func<int, int, int, int> method)
        {
            _customFunctions.Add(functionName, method);
        }

        /// <summary>
        /// Registers the custom integer function.
        /// </summary>
        /// <param name="functionName">Name of the function.</param>
        /// <param name="method">The method.</param>
        public void RegisterCustomIntegerFunction(string functionName, Func<int, int, int, int, int> method)
        {
            _customFunctions.Add(functionName, method);
        }

        /// <summary>
        /// Registers the custom double function.
        /// </summary>
        /// <param name="functionName">Name of the function.</param>
        /// <param name="method">The method.</param>
        public void RegisterCustomDoubleFunction(string functionName, Func<double, double> method)
        {
            _customFunctions.Add(functionName, method);
        }

        /// <summary>
        /// Registers the custom double function.
        /// </summary>
        /// <param name="functionName">Name of the function.</param>
        /// <param name="method">The method.</param>
        public void RegisterCustomDoubleFunction(string functionName, Func<double, double, double> method)
        {
            _customFunctions.Add(functionName, method);
        }

        /// <summary>
        /// Registers the custom double function.
        /// </summary>
        /// <param name="functionName">Name of the function.</param>
        /// <param name="method">The method.</param>
        public void RegisterCustomDoubleFunction(string functionName, Func<double, double, double, double> method)
        {
            _customFunctions.Add(functionName, method);
        }

        /// <summary>
        /// Registers the custom double function.
        /// </summary>
        /// <param name="functionName">Name of the function.</param>
        /// <param name="method">The method.</param>
        public void RegisterCustomDoubleFunction(string functionName, Func<double, double, double, double, double> method)
        {
            _customFunctions.Add(functionName, method);
        }

        /// <summary>
        /// Removes the function.
        /// </summary>
        /// <param name="functionName">Name of the function.</param>
        /// <exception cref="MathParser.Exceptions.NoSuchFunctionException"></exception>
        public void RemoveFunction(string functionName)
        {
            bool found = _functions.Any(f => f.Name.Equals(functionName));

            if (found)
            {
                int ndx = 0;

                while (ndx < _functions.Count)
                {
                    if (_functions[ndx].Name.Equals(functionName))
                        break;
                    ndx++;
                }
                _functions.RemoveAt(ndx);
                return;
            }

            throw new NoSuchFunctionException(StringResources.No_such_function_defined + ": " + functionName);
        }

        /// <summary>
        /// Adds the function.
        /// </summary>
        /// <param name="functionName">Name of the function.</param>
        /// <param name="argList">The argument list.</param>
        /// <param name="expression">The expression.</param>
        public void AddFunction(string functionName, FunctionArgumentList argList, string expression)
        {
            var fc = new FunctionClass { Arguments = argList, Expression = expression, Name = functionName };
            var numClass = new NumberClass { NumberType = NumberClass.NumberTypes.Expression, Expression = expression };

            EvaluateFunction(numClass, fc);

            _functions.Add(fc);
        }

        /// <summary>
        /// Removes all variables.
        /// </summary>
        public void RemoveAllVariables()
        {
            _variables.Clear();
        }

        /// <summary>
        /// Removes all functions.
        /// </summary>
        public void RemoveAllFunctions()
        {
            _functions.Clear();
        }

        /// <summary>
        /// Resets this instance.
        /// </summary>
        public void Reset()
        {
            RemoveAllFunctions();
            RemoveAllVariables();
            UnregisterAllCustomFunctions();
        }

        /// <summary>
        /// Removes the variable.
        /// </summary>
        /// <param name="varName">Name of the variable.</param>
        /// <exception cref="System.Exception"></exception>
        public void RemoveVariable(string varName)
        {
            if (_variables.ContainsKey(varName))
            {
                _variables.Remove(varName);
                return;
            }

            throw new Exception(StringResources.Undefined_Variable + ": " + varName);
        }

        /// <summary>
        /// Adds the variable.
        /// </summary>
        /// <param name="varName">Name of the variable.</param>
        /// <param name="valueType">Type of the value.</param>
        /// <exception cref="MathParser.Exceptions.VariableAlreadyDefinedException"></exception>
        private void AddVariable(string varName, NumberClass valueType)
        {
            if (_variables.ContainsKey(varName))
            {
                throw new VariableAlreadyDefinedException(StringResources.Variable_already_defined + ": " + varName);
            }

            if (valueType.NumberType == NumberClass.NumberTypes.Expression)
            {
                SimplificationReturnValue eeVal;

                eeVal = EvaluateExpression(valueType);

                if (eeVal.ReturnType == SimplificationReturnValue.ReturnTypes.Float)
                {
                    AddVariable(varName, eeVal.DoubleValue);
                    return;
                }
                if (eeVal.ReturnType == SimplificationReturnValue.ReturnTypes.Integer)
                {
                    AddVariable(varName, eeVal.IntValue);
                    return;
                }
            }
            _variables.Add(varName, valueType);
        }

        /// <summary>
        /// Adds the variable.
        /// </summary>
        /// <param name="varName">Name of the variable.</param>
        /// <param name="value">The value.</param>
        public void AddVariable(string varName, string value)
        {
            var nc = new NumberClass { NumberType = NumberClass.NumberTypes.Expression, Expression = value };

            AddVariable(varName, nc);
        }

        /// <summary>
        /// Adds the variable.
        /// </summary>
        /// <param name="varName">Name of the variable.</param>
        /// <param name="value">The value.</param>
        public void AddVariable(string varName, double value)
        {
            var nc = new NumberClass { NumberType = NumberClass.NumberTypes.Float, FloatNumber = value };

            AddVariable(varName, nc);
        }

        /// <summary>
        /// Adds the variable.
        /// </summary>
        /// <param name="varName">Name of the variable.</param>
        /// <param name="value">The value.</param>
        public void AddVariable(string varName, int value)
        {
            var nc = new NumberClass { NumberType = NumberClass.NumberTypes.Integer, IntNumber = value };

            AddVariable(varName, nc);
        }

        /// <summary>
        /// Evaluates the function.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <param name="fc">The fc.</param>
        private void EvaluateFunction(NumberClass expression, FunctionClass fc)
        {
            EvaluateFunction(expression, fc, new List<NumberClass> {
                               new NumberClass {NumberType = NumberClass.NumberTypes.Integer, IntNumber = 0}});
        }

        /// <summary>
        /// Evaluates the function.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <param name="fc">The fc.</param>
        /// <param name="ncList2">The nc list2.</param>
        /// <returns></returns>
        private SimplificationReturnValue EvaluateFunction(NumberClass expression, FunctionClass fc, IEnumerable<NumberClass> ncList2)
        {
            var parser = new Parser();
            var ncList = ncList2.ToList();

            foreach (var cfr in _customFunctions)
                parser.AddCustomFunction(cfr.Key, cfr.Value);

            foreach (var v in _variables)
            {
                if (v.Value.NumberType == NumberClass.NumberTypes.Float)
                {
                    parser.AddVariable(v.Key, v.Value.FloatNumber);
                }
                if (v.Value.NumberType == NumberClass.NumberTypes.Integer)
                {
                    parser.AddVariable(v.Key, v.Value.IntNumber);
                }
                if (v.Value.NumberType == NumberClass.NumberTypes.Expression)
                {
                    parser.AddVariable(v.Key, v.Value.Expression);
                }
            }

            foreach (var f in _functions)
            {
                parser.AddFunction(f.Name, f.Arguments, f.Expression);
            }

            int ndx = 0;
            foreach (var a in fc.Arguments)
            {
                NumberClass nc = ndx >= ncList.Count() ? new NumberClass { NumberType = NumberClass.NumberTypes.Integer, IntNumber = 0 } : ncList.ElementAt(ndx);

                if (nc.NumberType == NumberClass.NumberTypes.Float)
                {
                    try
                    {
                        parser.AddVariable(a, nc.FloatNumber);
                    } catch
                    {}
                }
                if (nc.NumberType == NumberClass.NumberTypes.Integer)
                {
                    try
                    {
                        parser.AddVariable(a, nc.IntNumber);
                    }catch
                    {
                    }
                }
                if (nc.NumberType == NumberClass.NumberTypes.Expression)
                    parser.AddVariable(a, nc.Expression);
                ndx++;
            }
            
            return parser.Simplify(expression.Expression);
        }

        /// <summary>
        /// Adds the custom function.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <param name="d">The d.</param>
        protected void AddCustomFunction(string s, Delegate d)
        {
            _customFunctions.Add(s, d);
        }

        /// <summary>
        /// Evaluates the expression.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        private SimplificationReturnValue EvaluateExpression(NumberClass expression)
        {
            var parser = new Parser();

            foreach (var cfh in _customFunctions)
                parser.AddCustomFunction(cfh.Key,cfh.Value);

            foreach (var v in _variables)
            {
                if (v.Value.NumberType == NumberClass.NumberTypes.Float)
                {
                    parser.AddVariable(v.Key, v.Value.FloatNumber);
                }
                if (v.Value.NumberType == NumberClass.NumberTypes.Integer)
                {
                    parser.AddVariable(v.Key, v.Value.IntNumber);
                }
                if (v.Value.NumberType == NumberClass.NumberTypes.Expression)
                {
                    parser.AddVariable(v.Key, v.Value.Expression);
                }
            }

            foreach (var f in _functions)
            {
                parser.AddFunction(f.Name, f.Arguments, f.Expression);
            }
            return parser.Simplify(expression.Expression);
        }

        /// <summary>
        /// Simplifies the object.
        /// </summary>
        /// <param name="equation">The equation.</param>
        /// <returns></returns>
        public object SimplifyObject(string equation)
        {
            var retval = Simplify(equation);

            if (retval.ReturnType == SimplificationReturnValue.ReturnTypes.Integer)
                return retval.IntValue;

            return retval.DoubleValue;
        }

        /// <summary>
        /// Simplifies the int.
        /// </summary>
        /// <param name="equation">The equation.</param>
        /// <param name="roundMethod">The round method.</param>
        /// <returns></returns>
        public int SimplifyInt(string equation, RoundingMethods roundMethod)
        {
            SimplificationReturnValue retval = Simplify(equation);

            if (retval.ReturnType == SimplificationReturnValue.ReturnTypes.Integer)
                return retval.IntValue;

            if (roundMethod == RoundingMethods.RoundDown)
                return (int)Math.Floor(retval.DoubleValue);
            if (roundMethod == RoundingMethods.RoundUp)
                return (int)Math.Ceiling(retval.DoubleValue);
            if (roundMethod == RoundingMethods.Round)
                return (int)Math.Round(retval.DoubleValue);

            return (int)Math.Truncate(retval.DoubleValue);

        }

        /// <summary>
        /// Simplifies the int.
        /// </summary>
        /// <param name="equation">The equation.</param>
        /// <returns></returns>
        public int SimplifyInt(string equation)
        {
            return SimplifyInt(equation, RoundingMethods.Round);
        }

        /// <summary>
        /// Simplifies the double.
        /// </summary>
        /// <param name="equation">The equation.</param>
        /// <returns></returns>
        public double SimplifyDouble(string equation)
        {
            SimplificationReturnValue retval = Simplify(equation);

            if (retval.ReturnType == SimplificationReturnValue.ReturnTypes.Float)
                return retval.DoubleValue;

            return double.Parse(retval.IntValue.ToString());
        }

        /// <summary>
        /// Simplifies the specified equation.
        /// </summary>
        /// <param name="equation">The equation.</param>
        /// <returns></returns>
        /// <exception cref="MathParser.Exceptions.NoSuchFunctionException">
        /// </exception>
        /// <exception cref="MathParser.Exceptions.NoSuchVariableException"></exception>
        /// <exception cref="MathParser.Exceptions.MismatchedParenthesisException">
        /// </exception>
        /// <exception cref="MathParser.Exceptions.CouldNotParseExpressionException">
        /// </exception>
        public SimplificationReturnValue Simplify(string equation)
        {
            var retval = new SimplificationReturnValue { OriginalEquation = equation };

            if (equation.Trim().StartsWith("-") || equation.Trim().StartsWith("+"))
                equation = "0" + equation;
            equation = equation.Replace("(+", "(0+");
            equation = equation.Replace("(-", "(0-");
            equation = equation.Replace("( +", "( 0+");
            equation = equation.Replace("( -", "( 0-");
            equation = equation.Replace(",-", ",0-");
            equation = equation.Replace(", -", ", 0-");
            equation = equation.Replace(",+", ",0+");
            equation = equation.Replace(", +", ", 0+");

            var tp = new TokenParser();

            foreach (var cf in _customFunctions)
            {
                tp.RegisterCustomFunction(cf.Key);
            }

            tp.InputString = equation;
            
            Token token = tp.GetToken();

            _operatorStack.Clear();
            _outputQueue.Clear();

            while (token != null)
            {
                if (token.TokenName == TokenParser.Tokens.Sqrt)
                {
                    #region SQR
                    string expression = token.TokenValue.Substring(4, token.TokenValue.Length - 4);

                    SimplificationReturnValue rv = EvaluateExpression(new NumberClass
                                                                          {
                                                                              Expression = expression,
                                                                              NumberType = NumberClass.NumberTypes.Expression
                                                                          });


                    token.TokenName = TokenParser.Tokens.Float;

                    switch (rv.ReturnType)
                    {
                        case SimplificationReturnValue.ReturnTypes.Integer:
                            token.TokenValue = Math.Sqrt(rv.IntValue).ToString();
                            break;
                        case SimplificationReturnValue.ReturnTypes.Float:
                            token.TokenValue = Math.Sqrt(rv.DoubleValue).ToString();
                            break;
                    }
                    #endregion SQR
                }
                if (token.TokenName == TokenParser.Tokens.Sin)
                {
                    #region SIN
                    string expression = token.TokenValue.Substring(3, token.TokenValue.Length - 3);

                    SimplificationReturnValue rv =
                        EvaluateExpression(new NumberClass
                        {
                            Expression = expression,
                            NumberType = NumberClass.NumberTypes.Expression
                        });

                    token.TokenName = TokenParser.Tokens.Float;

                    switch (rv.ReturnType)
                    {
                        case SimplificationReturnValue.ReturnTypes.Integer:
                            token.TokenValue = Math.Sin(rv.IntValue).ToString();
                            break;
                        case SimplificationReturnValue.ReturnTypes.Float:
                            token.TokenValue = Math.Sin(rv.DoubleValue).ToString();
                            break;
                    }
                    #endregion SIN
                }
                if (token.TokenName == TokenParser.Tokens.Log)
                {
                    #region LOG
                    string expression = token.TokenValue.Substring(3, token.TokenValue.Length - 3);

                    SimplificationReturnValue rv =
                        EvaluateExpression(new NumberClass
                        {
                            Expression = expression,
                            NumberType = NumberClass.NumberTypes.Expression
                        });

                    token.TokenName = TokenParser.Tokens.Float;

                    switch (rv.ReturnType)
                    {
                        case SimplificationReturnValue.ReturnTypes.Integer:
                            token.TokenValue = Math.Log(rv.IntValue, 10).ToString();
                            break;
                        case SimplificationReturnValue.ReturnTypes.Float:
                            token.TokenValue = Math.Log(rv.DoubleValue, 10).ToString();
                            break;
                    }
                    #endregion LOG
                }
                if (token.TokenName == TokenParser.Tokens.LogN)
                {
                    #region LogN
                    string expression = token.TokenValue.Substring(4, token.TokenValue.Length - 4);

                    SimplificationReturnValue rv =
                        EvaluateExpression(new NumberClass
                        {
                            Expression = expression,
                            NumberType = NumberClass.NumberTypes.Expression
                        });

                    token.TokenName = TokenParser.Tokens.Float;

                    switch (rv.ReturnType)
                    {
                        case SimplificationReturnValue.ReturnTypes.Integer:
                            token.TokenValue = Math.Log(rv.IntValue).ToString();
                            break;
                        case SimplificationReturnValue.ReturnTypes.Float:
                            token.TokenValue = Math.Log(rv.DoubleValue).ToString();
                            break;
                    }
                    #endregion LogN
                }
                if (token.TokenName == TokenParser.Tokens.Tan)
                {
                    #region TAN
                    string expression = token.TokenValue.Substring(3, token.TokenValue.Length - 3);

                    var rv =
                        EvaluateExpression(new NumberClass
                        {
                            Expression = expression,
                            NumberType = NumberClass.NumberTypes.Expression
                        });

                    token.TokenName = TokenParser.Tokens.Float;

                    switch (rv.ReturnType)
                    {
                        case SimplificationReturnValue.ReturnTypes.Integer:
                            token.TokenValue = Math.Tan(rv.IntValue).ToString();
                            break;
                        case SimplificationReturnValue.ReturnTypes.Float:
                            token.TokenValue = Math.Tan(rv.DoubleValue).ToString();
                            break;
                    }
                    #endregion TAN
                }
                if (token.TokenName == TokenParser.Tokens.Abs)
                {
                    #region ABS
                    string expression = token.TokenValue.Substring(3, token.TokenValue.Length - 3);

                    var rv =
                        EvaluateExpression(new NumberClass
                        {
                            Expression = expression,
                            NumberType = NumberClass.NumberTypes.Expression
                        });

                    token.TokenName = TokenParser.Tokens.Float;

                    switch (rv.ReturnType)
                    {
                        case SimplificationReturnValue.ReturnTypes.Integer:
                            token.TokenValue = Math.Abs(rv.IntValue).ToString();
                            break;
                        case SimplificationReturnValue.ReturnTypes.Float:
                            token.TokenValue = Math.Abs(rv.DoubleValue).ToString();
                            break;
                    }
                    #endregion ABS
                }
                if (token.TokenName == TokenParser.Tokens.Cos)
                {
                    #region COS
                    string expression = token.TokenValue.Substring(3, token.TokenValue.Length - 3);

                    var rv =
                        EvaluateExpression(new NumberClass
                        {
                            Expression = expression,
                            NumberType = NumberClass.NumberTypes.Expression
                        });

                    token.TokenName = TokenParser.Tokens.Float;

                    switch (rv.ReturnType)
                    {
                        case SimplificationReturnValue.ReturnTypes.Integer:
                            token.TokenValue = Math.Cos(rv.IntValue).ToString();
                            break;
                        case SimplificationReturnValue.ReturnTypes.Float:
                            token.TokenValue = Math.Cos(rv.DoubleValue).ToString();
                            break;
                    }
                    #endregion COS
                }
                if ((int)token.TokenName >= 100)
                {
                    #region Custom Function
                    int ndx1 = token.TokenValue.IndexOf("(");
                    string fn = token.TokenValue.Substring(0, ndx1);
                    string origExpression = token.TokenValue.Substring(ndx1);
                    string[] expressions = origExpression.Replace(",", "),(").Split(',');
                    bool found = false;

                    if (_customFunctions.Any(c => c.Key.Equals(fn)))
                        found = true;

                    if (found)
                    {
                        foreach (var ff in _customFunctions)
                        {
                            if (ff.Key.Equals(fn))
                            {
                                var p = new Parser();
                                foreach (var cfr in _customFunctions)
                                    p.AddCustomFunction(cfr.Key, cfr.Value);
                                foreach (var vr in _variables)
                                    p.AddVariable(vr.Key, vr.Value);
                                foreach (var vf in _functions)
                                    p.AddFunction(vf.Name, vf.Arguments, vf.Expression);

                                var ex = expressions.Select(p.Simplify).ToArray();

                                object funcRetval = null;

                                if (ff.Value.Method.ReturnType == typeof(int))
                                {
                                    var intParams = new object[ex.Length];
                                    int ndx = 0;

                                    foreach (var pp in ex)
                                    {
                                        if (pp.ReturnType == SimplificationReturnValue.ReturnTypes.Float)
                                            intParams[ndx] = (int)pp.DoubleValue;
                                        if (pp.ReturnType == SimplificationReturnValue.ReturnTypes.Integer)
                                            intParams[ndx] = pp.IntValue;
                                        ndx++;
                                    }
                                    funcRetval = ff.Value.DynamicInvoke(intParams);
                                }
                                if (ff.Value.Method.ReturnType == typeof(double))
                                {
                                    var floatParams = new object[ex.Length];
                                    int ndx = 0;

                                    foreach (var pp in ex)
                                    {
                                        if (pp.ReturnType == SimplificationReturnValue.ReturnTypes.Float)
                                            floatParams[ndx] = pp.DoubleValue;
                                        if (pp.ReturnType == SimplificationReturnValue.ReturnTypes.Integer)
                                            floatParams[ndx] = pp.IntValue;
                                        ndx++;
                                    }
                                    funcRetval = ff.Value.DynamicInvoke(floatParams);
                                }
                                if (ff.Value.Method.ReturnType==typeof(object))
                                {
                                    funcRetval = ff.Value.DynamicInvoke(expressions.Select(p.Simplify).ToArray());
                                }

                                //object funcRetval = ff.Value.DynamicInvoke(expressions.Select(p.Simplify).ToArray());

                                if (funcRetval is double)
                                {
                                    token.TokenValue = ((double)funcRetval).ToString();
                                    token.TokenName = TokenParser.Tokens.Float;
                                }
                                if (funcRetval is int)
                                {
                                    token.TokenValue = ((int)funcRetval).ToString();
                                    token.TokenName = TokenParser.Tokens.Integer;
                                }
                                if (funcRetval is SimplificationReturnValue)
                                {
                                    var srv = (SimplificationReturnValue)funcRetval;
                                    if (srv.ReturnType == SimplificationReturnValue.ReturnTypes.Integer)
                                    {
                                        token.TokenValue = srv.IntValue.ToString();
                                        token.TokenName = TokenParser.Tokens.Integer;
                                    }
                                    if (srv.ReturnType == SimplificationReturnValue.ReturnTypes.Float)
                                    {
                                        token.TokenValue = srv.DoubleValue.ToString();
                                        token.TokenName = TokenParser.Tokens.Float;
                                    }
                                }
                                break;
                            }
                        }
                    }

                    if (!found)
                    {
                        throw new NoSuchFunctionException(StringResources.No_such_function_defined + ": " + fn);
                    }
                    #endregion Custom Function
                }

                if (token.TokenName == TokenParser.Tokens.Function)
                {
                    #region Function
                    int ndx1 = token.TokenValue.IndexOf("(");
                    string fn = token.TokenValue.Substring(0, ndx1).Remove(0, 4);
                    string origExpression = token.TokenValue.Substring(ndx1);
                    string[] expressions = origExpression.Replace(",", "),(").Split(',');
                    bool found = false;
                    FunctionClass fun = null;

                    if (_functions.Any(c => c.Name.Equals(fn)))
                    {
                        found = true;
                    }

                    if (found)
                    {
                        foreach (var ff in _functions)
                            if (ff.Name.Equals(fn))
                                fun = ff;
                    }

                    if (!found)
                    {
                        throw new NoSuchFunctionException(StringResources.No_such_function_defined + ": " + fn);
                    }

                    var parser = new Parser();
                    foreach (var cfh in _customFunctions)
                        parser.AddCustomFunction(cfh.Key, cfh.Value);

                    foreach (var v in _variables)
                    {
                        if (v.Value.NumberType == NumberClass.NumberTypes.Float)
                        {
                            parser.AddVariable(v.Key, v.Value.FloatNumber);
                        }
                        if (v.Value.NumberType == NumberClass.NumberTypes.Integer)
                        {
                            parser.AddVariable(v.Key, v.Value.IntNumber);
                        }
                        if (v.Value.NumberType == NumberClass.NumberTypes.Expression)
                        {
                            parser.AddVariable(v.Key, v.Value.Expression);
                        }
                    }

                    foreach (var f in _functions)
                    {
                        parser.AddFunction(f.Name, f.Arguments, f.Expression);
                    }
                    var expressionList = new List<NumberClass>();

                    foreach (var expression in expressions)
                    {
                        SimplificationReturnValue simRetval = parser.Simplify(expression);

                        var numClass = new NumberClass();
                        if (simRetval.ReturnType == SimplificationReturnValue.ReturnTypes.Float)
                        {
                            numClass.FloatNumber = simRetval.DoubleValue;
                            numClass.NumberType = NumberClass.NumberTypes.Float;
                        }
                        if (simRetval.ReturnType == SimplificationReturnValue.ReturnTypes.Integer)
                        {
                            numClass.IntNumber = simRetval.IntValue;
                            numClass.NumberType = NumberClass.NumberTypes.Integer;
                        }
                        expressionList.Add(numClass);
                    }

                    if (fun != null)
                    {
                        var numClass = new NumberClass { NumberType = NumberClass.NumberTypes.Expression, Expression = fun.Expression };

                        SimplificationReturnValue sretval = parser.EvaluateFunction(numClass, fun, expressionList);

                        if (sretval != null && sretval.ReturnType == SimplificationReturnValue.ReturnTypes.Integer)
                        {
                            token.TokenName = TokenParser.Tokens.Integer;
                            token.TokenValue = sretval.IntValue.ToString();
                        }
                        if (sretval != null && sretval.ReturnType == SimplificationReturnValue.ReturnTypes.Float)
                        {
                            token.TokenName = TokenParser.Tokens.Float;
                            token.TokenValue = sretval.DoubleValue.ToString();
                        }
                    }
                    #endregion Function
                }

                if (token.TokenName == TokenParser.Tokens.Variable)
                {
                    #region Variable
                    if (_variables.ContainsKey(token.TokenValue))
                    {
                        var z = _variables[token.TokenValue];

                        if (z.NumberType == NumberClass.NumberTypes.Float)
                        {
                            token.TokenName = TokenParser.Tokens.Float;
                            token.TokenValue = z.FloatNumber.ToString();
                        }
                        else if (z.NumberType == NumberClass.NumberTypes.Integer)
                        {
                            token.TokenName = TokenParser.Tokens.Integer;
                            token.TokenValue = z.IntNumber.ToString();
                        }
                    }
                    else
                    {
                        throw new NoSuchVariableException(StringResources.Undefined_Variable + ": " + token.TokenValue);
                    }
                    #endregion Variable
                }

                if (token.TokenName == TokenParser.Tokens.Whitespace || token.TokenName == TokenParser.Tokens.Newline)
                {
                    #region WhiteSpace
                    token = tp.GetToken();
                    continue;
                    #endregion WhiteSpace
                }
                if (token.TokenName == TokenParser.Tokens.Integer || token.TokenName == TokenParser.Tokens.Float)
                {
                    #region Number
                    var nc = new NumberClass();

                    switch (token.TokenName)
                    {
                        case TokenParser.Tokens.Float:
                            nc.NumberType = NumberClass.NumberTypes.Float;
                            nc.FloatNumber = double.Parse(token.TokenValue);
                            break;
                        case TokenParser.Tokens.Integer:
                            nc.NumberType = NumberClass.NumberTypes.Integer;
                            nc.IntNumber = int.Parse(token.TokenValue);
                            break;
                    }
                    _outputQueue.Enqueue(nc);
                    #endregion Number
                }
                if (IsOperator(token.TokenName))
                {
                    #region Operator
                    if (_operatorStack.Count > 0)
                    {
                        while (_operatorStack.Count > 0)
                        {
                            var op = _operatorStack.Peek(); //o2    

                            if (op == "(" || op == ")")
                                break;
                            if ((GetPrecedence(token.TokenName) <= GetPrecedence(op) &&
                                 IsLeftAssociative(token.TokenValue)) ||
                                !IsLeftAssociative(token.TokenValue) &&
                                GetPrecedence(token.TokenName) < GetPrecedence(op))
                            {
                                op = _operatorStack.Pop();
                                var nc = new NumberClass { NumberType = NumberClass.NumberTypes.Operator, Operator = op };

                                _outputQueue.Enqueue(nc);
                            }
                            else break;
                        }
                    }
                    _operatorStack.Push(token.TokenValue);
                    #endregion Operator
                }
                if (token.TokenName == TokenParser.Tokens.Lparen)
                {
                    #region Left Parenthesis
                    _operatorStack.Push(token.TokenValue);
                    #endregion Left Parenthesis
                }
                if (token.TokenName == TokenParser.Tokens.Rparen)
                {
                    #region Right Parenthesis
                    if (_operatorStack.Count > 0)
                    {
                        var op = _operatorStack.Pop();

                        while (op != "(")
                        {
                            var nc = new NumberClass { Operator = op, NumberType = NumberClass.NumberTypes.Operator };

                            _outputQueue.Enqueue(nc);

                            if (_operatorStack.Count > 0)
                                op = _operatorStack.Pop();
                            else
                            {
                                throw new MismatchedParenthesisException();
                            }
                        }
                    }
                    else
                    {
                        throw new MismatchedParenthesisException();
                    }
                    #endregion Right Parenthesis
                }
                token = tp.GetToken();
            }

            while (_operatorStack.Count > 0)
            {
                var op = _operatorStack.Pop();

                if (op == "(" || op == ")")
                {
                    throw new MismatchedParenthesisException();
                }

                var nc = new NumberClass { NumberType = NumberClass.NumberTypes.Operator, Operator = op };

                _outputQueue.Enqueue(nc);
            }

            bool floatAnswer = _outputQueue.Any(v => v.NumberType == NumberClass.NumberTypes.Float);

            if (floatAnswer || _outputQueue.Any(v => v.Operator == "/"))
            {
                var dblStack = new Stack<double>();

                foreach (var nc in _outputQueue)
                {
                    if (nc.NumberType == NumberClass.NumberTypes.Integer)
                        dblStack.Push(nc.IntNumber);
                    if (nc.NumberType == NumberClass.NumberTypes.Float)
                        dblStack.Push(nc.FloatNumber);
                    if (nc.NumberType == NumberClass.NumberTypes.Operator)
                    {
                        double val = DoMath(nc.Operator, dblStack.Pop(), dblStack.Pop());

                        dblStack.Push(val);
                    }
                }

                if (dblStack.Count == 0)
                {
                    throw new CouldNotParseExpressionException();
                }
                retval.DoubleValue = dblStack.Pop();
                retval.ReturnType = SimplificationReturnValue.ReturnTypes.Float;
            }
            else
            {
                var intStack = new Stack<int>();

                foreach (var nc in _outputQueue)
                {
                    if (nc.NumberType == NumberClass.NumberTypes.Integer)
                        intStack.Push(nc.IntNumber);
                    if (nc.NumberType == NumberClass.NumberTypes.Float)
                        intStack.Push((int)nc.FloatNumber);
                    if (nc.NumberType == NumberClass.NumberTypes.Operator)
                    {
                        int val = DoMath(nc.Operator, intStack.Pop(), intStack.Pop());

                        intStack.Push(val);
                    }
                }

                if (intStack.Count == 0)
                {
                    throw new CouldNotParseExpressionException();
                }
                retval.IntValue = intStack.Pop();
                retval.ReturnType = SimplificationReturnValue.ReturnTypes.Integer;
            }

            return retval;
        }

        /// <summary>
        /// Gets the variable names.
        /// </summary>
        /// <param name="equation">The equation.</param>
        /// <returns></returns>
        public List<string> GetVariableNames(string equation)
        {
            List<string> returnValue = new List<string>();

            TokenParser tp = new TokenParser();

            foreach (var cf in _customFunctions)
            {
                tp.RegisterCustomFunction(cf.Key);
            }

            tp.InputString = equation;

            Token token = tp.GetToken();

            while (token != null)
            {
                if (token.TokenName == TokenParser.Tokens.Variable)
                {
                    returnValue.Add(token.TokenValue);
                }
                token = tp.GetToken();
            }

            return (returnValue);
        }

        /// <summary>
        /// Does the math.
        /// </summary>
        /// <param name="op">The op.</param>
        /// <param name="val1">The val1.</param>
        /// <param name="val2">The val2.</param>
        /// <returns></returns>
        private static double DoMath(string op, double val1, double val2)
        {
            if (op == "*")
                return val1 * val2;
            if (op == "/")
                return val2 / val1;
            if (op == "+")
                return val1 + val2;
            if (op == "-")
                return val2 - val1;
            if (op == "%")
                return val2 % val1;
            if (op == "^")
                return Math.Pow(val2, val1);

            return 0f;
        }

        /// <summary>
        /// Does the math.
        /// </summary>
        /// <param name="op">The op.</param>
        /// <param name="val1">The val1.</param>
        /// <param name="val2">The val2.</param>
        /// <returns></returns>
        private static int DoMath(string op, int val1, int val2)
        {
            if (op == "*")
                return val1 * val2;
            if (op == "/")
                return val2 / val1;
            if (op == "+")
                return val1 + val2;
            if (op == "-")
                return val2 - val1;
            if (op == "%")
                return val2 % val1;
            if (op == "^")
                return (int)Math.Pow(val2, val1);

            return 0;
        }

        /// <summary>
        /// Determines whether [is left associative] [the specified op].
        /// </summary>
        /// <param name="op">The op.</param>
        /// <returns></returns>
        private static bool IsLeftAssociative(string op)
        {
            return op == "*" || op == "+" || op == "-" || op == "/" || op == "%";
        }

        /// <summary>
        /// Gets the precedence.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        private static int GetPrecedence(TokenParser.Tokens token)
        {
            if (token == TokenParser.Tokens.Add || token == TokenParser.Tokens.Subtract)
                return 1;

            if (token == TokenParser.Tokens.Multiply || token == TokenParser.Tokens.Divide || token == TokenParser.Tokens.Modulus)
                return 2;

            if (token == TokenParser.Tokens.Exponent)
                return 3;

            if (token == TokenParser.Tokens.Lparen || token == TokenParser.Tokens.Rparen)
                return 4;

            return 0;
        }

        /// <summary>
        /// Gets the precedence.
        /// </summary>
        /// <param name="op">The op.</param>
        /// <returns></returns>
        private static int GetPrecedence(string op)
        {
            if (op.Equals("+") || op.Equals("-"))
                return 1;

            if (op.Equals("*") || op.Equals("/") || op.Equals("%"))
                return 2;

            if (op.Equals("^"))
                return 3;

            if (op.Equals("(") || op.Equals(")"))
                return 4;

            return 0;
        }

        /// <summary>
        /// Determines whether the specified token is operator.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        private static bool IsOperator(TokenParser.Tokens token)
        {
            return token == TokenParser.Tokens.Add || token == TokenParser.Tokens.Divide || token == TokenParser.Tokens.Exponent ||
                   token == TokenParser.Tokens.Modulus || token == TokenParser.Tokens.Multiply || token == TokenParser.Tokens.Subtract;
        }

        /// <summary>
        /// 
        /// </summary>
        private class FunctionClass
        {
            /// <summary>
            /// Gets or sets the expression.
            /// </summary>
            /// <value>
            /// The expression.
            /// </value>
            public string Expression
            {
                get;
                set;
            }

            /// <summary>
            /// Gets or sets the name.
            /// </summary>
            /// <value>
            /// The name.
            /// </value>
            public string Name
            {
                get;
                set;
            }

            /// <summary>
            /// Gets or sets the arguments.
            /// </summary>
            /// <value>
            /// The arguments.
            /// </value>
            public FunctionArgumentList Arguments
            {
                get;
                set;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private class NumberClass
        {
            /// <summary>
            /// 
            /// </summary>
            public enum NumberTypes
            {
                Float,
                Integer,
                Operator,
                Expression
            }

            /// <summary>
            /// Gets or sets the type of the number.
            /// </summary>
            /// <value>
            /// The type of the number.
            /// </value>
            public NumberTypes NumberType
            {
                get;
                set;
            }

            /// <summary>
            /// Gets or sets the int number.
            /// </summary>
            /// <value>
            /// The int number.
            /// </value>
            public int IntNumber
            {
                get;
                set;
            }

            /// <summary>
            /// Gets or sets the float number.
            /// </summary>
            /// <value>
            /// The float number.
            /// </value>
            public double FloatNumber
            {
                get;
                set;
            }

            /// <summary>
            /// Gets or sets the operator.
            /// </summary>
            /// <value>
            /// The operator.
            /// </value>
            public string Operator
            {
                get;
                set;
            }

            /// <summary>
            /// Gets or sets the expression.
            /// </summary>
            /// <value>
            /// The expression.
            /// </value>
            public string Expression
            {
                get;
                set;
            }
        }
    }
}
