import { prisma } from "@/lib/db";
import { NextRequest, NextResponse } from "next/server";

export async function POST(req: NextRequest) {
    const body = await req.json();
    console.log("body", body);
    const newProduct = await prisma.product.create({
        data: {
            name: body.name,
            price: Number(body.price),
            description: body.description,
        },
    });

    return NextResponse.json({ newProduct }, { status: 201 });
}
