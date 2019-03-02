using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RyzenADJ
{
    unsafe class RyzenAdjAPI
    {
        [DllImport("RyzenAdjAPI.dll")]
        public static extern bool init_ryzenadj_library();

        [DllImport("RyzenAdjAPI.dll")]
        public static extern int set_stapm_limit(uint value);

        [DllImport("RyzenAdjAPI.dll")]
        public static extern int set_fast_limit(uint value);

        [DllImport("RyzenAdjAPI.dll")]
        public static extern int set_slow_limit(uint value);

        [DllImport("RyzenAdjAPI.dll")]
        public static extern int set_slow_time(uint value);

        [DllImport("RyzenAdjAPI.dll")]
        public static extern int set_stapm_time(uint value);

        [DllImport("RyzenAdjAPI.dll")]
        public static extern int set_tctl_temp(uint value);

        [DllImport("RyzenAdjAPI.dll")]
        public static extern int set_vrm_current(uint value);

        [DllImport("RyzenAdjAPI.dll")]
        public static extern int set_vrmsoc_current(uint value);

        [DllImport("RyzenAdjAPI.dll")]
        public static extern int set_vrmmax_current(uint value);

        [DllImport("RyzenAdjAPI.dll")]
        public static extern int set_vrmsocmax_current(uint value);

        [DllImport("RyzenAdjAPI.dll")]
        public static extern int set_psi0_current(uint value);

        [DllImport("RyzenAdjAPI.dll")]
        public static extern int set_psi0soc_current(uint value);

        [DllImport("RyzenAdjAPI.dll")]
        public static extern void cleanup_ryzenadj_library();
    }
}
