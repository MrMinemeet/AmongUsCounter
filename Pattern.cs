namespace AmongUsCounter; 

public static class Pattern {
	// 0 --> Any other color than 1 or 2
	// 1 --> Suit color
	// 2 --> Visor
	// 3 --> Don't care color
	
	private static readonly byte[,] NORMAL_RIGHT_FACING = new byte[,] {
		{0, 1, 1, 1},	//   * * *
		{1, 1, 2, 2},	// * * _ _
		{1, 1, 1, 1},	// * * * *
		{0, 1, 1, 1},	//   * * *
		{0, 1, 0, 1}	//   *   *
	};
	
	private static readonly byte[,] NORMAL_LEFT_FACING = new byte[,] {
		{1, 1, 1, 0},	// * * *
		{2, 2, 1, 1},	// _ _ * *
		{1, 1, 1, 1},	// * * * *
		{1, 1, 1, 0},	// * * *
		{1, 0, 1, 0}	// *   *
	};
	
	private static readonly byte[,] BIGPACK_RIGHT_FACING = new byte[,] {
		{0, 1, 1, 1},	//   * * *
		{1, 1, 2, 2},	// * * _ _
		{1, 1, 1, 1},	// * * * *
		{1, 1, 1, 1},	// * * * *
		{0, 1, 0, 1}	//   *   *
	};
	
	private static readonly byte[,] BIGPACK_LEFT_FACING = new byte[,] {
		{1, 1, 1, 0},	// * * *
		{2, 2, 1, 1},	// _ _ * *
		{1, 1, 1, 1},	// * * * *
		{1, 1, 1, 1},	// * * * *
		{1, 0, 1, 0}	// *   *
	};
	
	private static readonly byte[,] NOPACK_RIGHT_FACING = new byte[,] {
		{1, 1, 1},	// * * *
		{1, 2, 2},	// * _ _
		{1, 1, 1},	// * * *
		{1, 1, 1},	// * * *
		{1, 0, 1}	// *   *
	};
	
	private static readonly byte[,] NOPACK_LEFT_FACING = new byte[,] {
		{1, 1, 1},	// * * *
		{2, 2, 1},	// _ _ *  
		{1, 1, 1},	// * * *  
		{1, 1, 1},	// * * *  
		{1, 0, 1}	// *   *
	};
	
	private static readonly byte[,] SMALL_RIGHT_FACING = new byte[,] {
		{0, 1, 1, 1},	//   * * *
		{1, 1, 2, 2},	// * * _ _
		{1, 1, 1, 1},	// * * * *
		{0, 1, 0, 1}	//   *   *
	};
	
	private static readonly byte[,] SMALL_LEFT_FACING = new byte[,] {
		{1, 1, 1, 0},	// * * *
		{2, 2, 1, 1},	// _ _ * *
		{1, 1, 1, 1},	// * * * *
		{1, 0, 1, 0}	// *   *
	};
	
	private static readonly byte[,] BIGVISOR_RIGHT_FACING = new byte[,] {
		{0, 1, 1, 1},	//   * * *
		{1, 1, 2, 3},	// * * _  
		{1, 1, 2, 2},	// * * _ _
		{0, 1, 1, 1},	//   * * *
		{0, 1, 0, 1}	//   *   *
	};
	
	private static readonly byte[,] BIGVISOR_LEFT_FACING = new byte[,] {
		{1, 1, 1, 0},	// * * *
		{3, 2, 1, 1},	//   _ * *
		{2, 2, 1, 1},	// _ _ * *
		{1, 1, 1, 0},	// * * *
		{1, 0, 1, 0}	// *   *
	};
	
	private static readonly byte[,] TALL_RIGHT_FACING = new byte[,] {
		{0, 1, 1, 1},	//   * * *
		{1, 1, 2, 2},	// * * _ _
		{1, 1, 1, 1},	// * * * *
		{1, 1, 1, 1},	// * * * *
		{0, 1, 1, 1},	//   * * *
		{0, 1, 0, 1}	//   *   *
	};
	
	private static readonly byte[,] TALL_LEFT_FACING = new byte[,] {
		{1, 1, 1, 0},	// * * *
		{2, 2, 1, 1},	// _ _ * *
		{1, 1, 1, 1},	// * * * *
		{1, 1, 1, 1},	// * * * *
		{1, 1, 1, 0},	// * * *
		{1, 0, 1, 0}	// *   *
	};
	
	private static readonly byte[,] TALL_BIGVISOR_RIGHT_FACING = new byte[,] {
		{0, 1, 1, 1},	//   * * *
		{1, 1, 2, 3},	// * * _  
		{1, 1, 2, 2},	// * * _ _
		{1, 1, 1, 1},	// * * * *
		{0, 1, 1, 1},	//   * * *
		{0, 1, 0, 1}	//   *   *
	};
	
	private static readonly byte[,] TALL_BIGVISOR_LEFT_FACING = new byte[,] {
		{1, 1, 1, 0},	// * * *
		{3, 2, 1, 1},	//   _ * *
		{2, 2, 1, 1},	// _ _ * *
		{1, 1, 1, 1},	// * * * *
		{1, 1, 1, 0},	// * * *
		{1, 0, 1, 0}	// *   *
	};
	
	private static readonly List<byte[,]> PatternList = new List<byte[,]> { 
		NORMAL_RIGHT_FACING, NORMAL_LEFT_FACING, 
		BIGPACK_RIGHT_FACING , BIGPACK_LEFT_FACING,
		NOPACK_RIGHT_FACING, NOPACK_LEFT_FACING,
		SMALL_RIGHT_FACING, SMALL_LEFT_FACING,
		BIGVISOR_RIGHT_FACING, BIGVISOR_LEFT_FACING,
		TALL_RIGHT_FACING, TALL_LEFT_FACING,
		TALL_BIGVISOR_RIGHT_FACING, TALL_BIGVISOR_LEFT_FACING
	};

	public static List<byte[,]> GetPatternList() {
		return PatternList;
	}
}