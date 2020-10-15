using System;
using System.Runtime.InteropServices;

namespace Mt32emu.Interop
{
    internal sealed class Mt32ContextSafeHandle : SafeHandle
    {
        public Mt32ContextSafeHandle()
            : base(IntPtr.Zero, true)
        {
        }

        public override bool IsInvalid => this.handle == IntPtr.Zero;

        protected override bool ReleaseHandle()
        {
            NativeMethods.mt32emu_free_context(this.handle);
            return true;
        }
    }
}
