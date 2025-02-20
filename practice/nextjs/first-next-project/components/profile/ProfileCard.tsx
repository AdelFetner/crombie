import Image from 'next/image'
import React from 'react'

type Props = {
    userData: {
        username: string,
        email: string,
        img: string
    }
}

export const ProfileCard = ({ userData }: Props) => {
    const { username, email, img } = userData

    return (
        <article className='flex flex-col items-center'>
            <Image src={img} alt="profile picture" height={600} width={600} />
            <h2>{username}</h2>
            <p>{email}</p>
        </article>
    )
}