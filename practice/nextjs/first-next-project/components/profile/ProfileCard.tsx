"use client"
import Image from 'next/image'
import React from 'react'
import { Card, CardBody, CardHeader } from "@heroui/react";

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
        <Card className="py-4">
            <CardHeader className="pb-0 pt-2 px-4 flex-col items-start">
                <p className="text-tiny uppercase font-bold">{username}</p>
                <h4 className="font-bold text-large">{email}</h4>
            </CardHeader>
            <CardBody className="overflow-visible py-2">
                <Image
                    alt="Card background"
                    className="object-cover rounded-xl"
                    src={img}
                    width={270}
                    height={180}
                />
            </CardBody>
        </Card>
    )
}