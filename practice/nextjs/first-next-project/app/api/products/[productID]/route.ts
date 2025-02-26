import { prisma } from "@/lib/db";
import { NextRequest, NextResponse } from "next/server";

export async function GET(
    req: NextRequest,
    { params }: { params: { productID: string } }
) {
    const productID = (await params).productID;

    const product = await prisma.product.findUnique({
        where: {
            id: productID,
        },
    });
    return NextResponse.json({ product }, { status: 200 });
}
