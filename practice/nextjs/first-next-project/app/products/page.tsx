import { ProductCard } from '@/components/products/ProductCard'
import { prisma } from '@/lib/db';

type Product = {
    name: string
    description: string | null
    price: number
    image: string | null
}

export default async function ProductsPage() {
    console.log(await prisma.product.findMany({
        select: {
            name: true,
            description: true,
            price: true,
            image: true
        }
    }))
    const products: Product[] = await prisma.product.findMany({
        select: {
            name: true,
            description: true,
            price: true,
            image: true
        }
    })

    return (
        <main className='flex flex-col items-center justify-center h-screen min-h-full w-full min-w-full'>
            <h1>All Products</h1>
            <div className='flex flex-wrap gap-4'>
                {products.map((product, index) => (
                    <ProductCard productData={product} key={index} />
                ))}
            </div>
        </main>
    )
}