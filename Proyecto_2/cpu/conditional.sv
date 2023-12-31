///////////////////////////////////////////////////////////////////////////////
// Module Name:   conditional
// Description:   This module performs conditional operations and flag management.
//
// Inputs:        Cond - Condition signal
//                Flags - Current flag values
//                ALUFlags - Flags generated by the ALU
//                FlagsWrite - Control for writing to flags
//
// Outputs:       CondEx - Condition result after conditional operation
//                FlagsNext - Updated flag values
//
// Usage:         Instantiate this module in your design to handle conditional
//                operations and manage flag updates based on conditions.
//
// Example Usage:
// ```
//   conditional myConditional (
//     .Cond(condition_signal),
//     .Flags(current_flags),
//     .ALUFlags(ALU_generated_flags),
//     .FlagsWrite(flag_write_control),
//     .CondEx(condition_result),
//     .FlagsNext(updated_flags)
//   );
// ```
///////////////////////////////////////////////////////////////////////////////

module conditional (
    input logic        Cond,  // Condition signal
    input logic [3:0]  Flags,  // Current flag values
    input logic [3:0]  ALUFlags,  // Flags generated by the ALU
    input logic [1:0]  FlagsWrite,  // Control for writing to flags
    output logic       CondEx,  // Condition result after conditional operation
    output logic [3:0] FlagsNext  // Updated flag values
);

    logic zero; 
    assign zero = Flags[2];  // Extract the Z (zero) flag from the current flags

    always_comb
        case(Cond)
            1'b1:    CondEx = zero; // EQV: Condition result is the zero flag
            1'b0:    CondEx = 1'b1; // Always: Condition result is always true
            default: CondEx = 1'bx; // Undefined: Condition result is undefined
        endcase

    // Update the flag values based on the FlagsWrite control
    // If FlagsWrite[1] is set and the condition is true (CondEx), update the upper 2 bits
    assign FlagsNext[3:2] = (FlagsWrite[1] & CondEx) ? ALUFlags[3:2] : Flags[3:2];
    // If FlagsWrite[0] is set and the condition is true (CondEx), update the lower 2 bits
    assign FlagsNext[1:0] = (FlagsWrite[0] & CondEx) ? ALUFlags[1:0] : Flags[1:0];

endmodule