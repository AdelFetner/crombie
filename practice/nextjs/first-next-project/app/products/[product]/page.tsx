import { fakeDB } from '@/app/lib/fakeDB'
import Image from 'next/image'
import { notFound } from 'next/navigation'

export async function generateStaticParams() {
    return fakeDB.Products.map(product => ({
        product: product.name.toLowerCase().replace(/ /g, '-'),
    }))
}

export default function ProductPage({ params }: { params: { product: string } }) {
    const productName = params.product.replace(/-/g, ' ')
    const product = fakeDB.Products.find(product =>
        product.name.toLowerCase() === productName.toLowerCase()
    )

    if (!product) return notFound()

    return (
        <main className='flex flex-col items-center justify-center h-screen min-h-full w-full min-w-full'>
            <h1>{product.name}</h1>
            <p>Price: ${product.price}</p>
            <p>{product.description}</p>
            <Image src={product.img} alt={product.name} className='w-48 h-48' height={580} width={580} />
        </main>
    )
}