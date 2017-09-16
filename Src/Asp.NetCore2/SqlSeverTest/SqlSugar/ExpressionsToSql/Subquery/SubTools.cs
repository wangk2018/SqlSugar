﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SqlSugar
{
    public class SubTools
    {
        public static List<ISubOperation> SubItems(ExpressionContext Context)
        {

                return new List<ISubOperation>()
                                                {
                                                    new SubSelect() { Context=Context },
                                                    new SubWhere(){ Context=Context },
                                                    new SubAnd(){ Context=Context },
                                                    new SubAny(){ Context=Context },
                                                    new SubNotAny(){ Context=Context },
                                                    new SubBegin(){ Context=Context },
                                                    new SubFromTable(){ Context=Context },
                                                    new SubCount(){ Context=Context },
                                                    new SubMax(){ Context=Context },
                                                    new SubMin(){ Context=Context }
                                                };
        }

        public static List<ISubOperation> SubItemsConst = SubItems(null);

        public static string GetMethodValue(ExpressionContext context, Expression item, ResolveExpressType type)
        {
            var newContext = context.GetCopyContext();
            newContext.MappingColumns = context.MappingColumns;
            newContext.MappingTables = context.MappingTables;
            newContext.IgnoreComumnList = context.IgnoreComumnList;
            newContext.Resolve(item, type);
            context.Index = newContext.Index;
            context.ParameterIndex = newContext.ParameterIndex;
            return newContext.Result.GetResultString();
        }
    }
}
