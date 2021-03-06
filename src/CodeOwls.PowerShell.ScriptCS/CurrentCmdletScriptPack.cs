/*
    Copyright (c) 2013 Code Owls LLC, All Rights Reserved.

    Licensed under the Apache License, Version 2.0 (the "License");
    you may not use this file except in compliance with the License.
    You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

    Unless required by applicable law or agreed to in writing, software
    distributed under the License is distributed on an "AS IS" BASIS,
    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
    See the License for the specific language governing permissions and
    limitations under the License.
*/


using System;
using System.Management.Automation;
using System.Reflection;
using ScriptCs.Contracts;

namespace CodeOwls.PowerShell.ScriptCS
{
    public class CurrentCmdletScriptPack : IScriptPack
    {
        private readonly CurrentCmdletContext _context;

        public CurrentCmdletScriptPack()
        {
            _context = new CurrentCmdletContext( new NullCmdletContext() );
        }

        public void Initialize(IScriptPackSession session)
        {
            session.AddReference(typeof (PSCmdlet).Assembly.FullName);
            session.AddReference(typeof (IScriptPackContext).Assembly.Location);
            session.AddReference(Assembly.GetExecutingAssembly().Location);
        }

        public IScriptPackContext GetContext()
        {
            return _context;
        }

        public void Terminate()
        {
        }

        public IDisposable CreateActiveCmdletSession( ICmdletContext cmdlet )
        {
            return new CmdletScope(_context, cmdlet);
        }

        class CmdletScope : IDisposable
        {
            private readonly CurrentCmdletContext _context;
            private readonly ICmdletContext _previousCmdletContext;

            public CmdletScope( CurrentCmdletContext context, ICmdletContext cmdlet )
            {
                _context = context;
                _previousCmdletContext = _context.ActiveCmdletContext;
                _context.ActiveCmdletContext = cmdlet;
            }

            public void Dispose()
            {
                _context.ActiveCmdletContext = _previousCmdletContext;
            }
        }
    }
}
