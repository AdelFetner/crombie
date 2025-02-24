"use client"
import { Card } from '@heroui/react'
import Image from 'next/image'
import Link from 'next/link'
import React from 'react'

type Props = {
    productData: {
        name: string,
        description: string | null,
        price: number,
        image: string | null
    }
}

export const ProductCard = ({ productData }: Props) => {
    const { name, description, price, image } = productData

    return (
        <Card className="min-w-72 w-72 max-w-72 bg-white border border-gray-200 rounded-lg shadow-sm dark:bg-gray-800 dark:border-gray-700">
            <Link href="products/">
                <Image className="rounded-t-lg" src={image ?? "https://picsum.photos/600"} alt={description ?? "this is an image of a product"} width={300} height={300} />
            </Link>
            <div className="p-5">
                <Link href="#">
                    <h2 className="mb-2 text-2xl font-bold tracking-tight text-gray-900 dark:text-white">{name}</h2>
                </Link>
                <p className="mb-3 font-normal text-gray-700 dark:text-gray-400">{description ?? ""}</p>
                <Link href={`products/${name.toLowerCase().replace(/ /g, '-')}`} className="inline-flex items-center px-3 py-2 text-sm font-medium text-center text-white bg-blue-700 rounded-lg hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 dark:bg-blue-600 dark:hover:bg-blue-700 dark:focus:ring-blue-800">
                    ${price}
                    <svg className="rtl:rotate-180 w-3.5 h-3.5 ms-2" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 14 10">
                        <path stroke="currentColor" strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M1 5h12m0 0L9 1m4 4L9 9" />
                    </svg>
                </Link>
            </div>
        </Card>

    )
}