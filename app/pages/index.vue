<template>
	<v-container fluid>
		<v-row justify='end'>
			<v-col cols='4'>
				<v-text-field v-model='search' outlined placeholder='Search..'/>
			</v-col>
		</v-row>
		<v-row>
			<v-col cols='12'>
				<ItemDialog ref='dialog'/>
				<v-data-table hide-default-footer :search='search' :items='stocks' :headers='headers'>
					<template #item.estimatedProfit='{ item, value }'>
						<span :class='{ "value-positive": value > 0, "value-negative": value < 0 }' v-text='value && value + " USD"'/>
					</template>
					<template #item.estimatedProfitPercentage='{ item, value }'>
						<span :class='{ "value-positive": value > 0, "value-negative": value < 0 }' v-text='((value && !isNaN(value)) && value + "%") || ""'/>
					</template>
					<template #item.lastUpdate='{ item, value }'>
						<span v-text='value && $moment(value).fromNow()'/>
					</template>
					<template #item.actions='{ item }'>
						<v-icon v-text='"mdi-lead-pencil"' @click='edit(item)'/>
						<v-icon v-text='"mdi-delete"' @click='remove(item)'/>
					</template>
				</v-data-table>
			</v-col>
		</v-row>
		<v-row justify='end'>
			<v-col cols='auto'>
				<v-btn outlined v-text='"Add"' @click='$refs.dialog.open()'/>
			</v-col>
		</v-row>
	</v-container>
</template>

<script>
	import ItemDialog from './index/partials/ItemDialog'

	export default
	{
		components: { ItemDialog },
		data: () =>
		({
			search: null
		}),
		mounted()
		{
			this.openSocket()
		},
		computed:
		{
			stocks()
			{
				var stocks = this.$store.state.stocks.items.map((b, idx) => Object.assign({ index: idx }, b))

				stocks.forEach(x => this.$set(x, 'marketValue', null))
				stocks.forEach(x => this.$set(x, 'estimatedProfit', null))
				stocks.forEach(x => this.$set(x, 'estimatedProfitPercentage', null))
				stocks.forEach(x => this.$set(x, 'lastUpdate', null))

				return stocks
			},
			headers()
			{
				var headers =
				[
					{
						text: 'Name',
						value: 'name'
					},
					{
						text: 'Symbol',
						value: 'symbol'
					},
					{
						text: 'Quantity',
						value: 'quantity'
					},
					{
						text: 'Invested Value',
						value: 'investedValue'
					},
					{
						text: 'Market Value',
						value: 'marketValue'
					},
					{
						text: 'Est. Profit',
						value: 'estimatedProfit'
					},
					{
						text: 'Est. Profit (%)',
						value: 'estimatedProfitPercentage'
					},
					{
						text: 'Last Update',
						value: 'lastUpdate'
					},
					{
						text: 'Actions',
						value: 'actions',
						align: 'center'
					}
				]

				return headers
			}
		},
		watch:
		{
			stocks:
			{
				handler()
				{
					this.openSocket()
				},
				deep: true
			}
		},
		methods:
		{
			edit(stock)
			{
				this.$refs.dialog.open(Object.assign({}, stock))
			},
			remove(stock)
			{
				this.$store.dispatch('stocks/delete', stock)
			},
			openSocket()
			{
				var socket = new WebSocket('wss://ws.finnhub.io?token=' + process.env.finnhub.key)

				socket.onopen = () =>
				{
					var symbols = this.stocks.map(x => x.symbol)

					symbols.forEach(x => socket.send(JSON.stringify(
					{
						type: 'subscribe',
						symbol: x
					})))
				}

				socket.onmessage = (e) =>
				{
					// show notification on error
					var result = JSON.parse(e.data)

					if(result.type == "trade")
					{
						result.data.forEach(data =>
						{
							var stock = this.stocks.find(x => x.symbol == data.s)

							if(!stock)
								return

							stock.marketValue = data.p.toFixed(2)
							stock.estimatedProfit = ((stock.marketValue * stock.quantity) - stock.investedValue).toFixed(2)
							stock.estimatedProfitPercentage = ((stock.estimatedProfit / stock.investedValue) * 100).toFixed(2)
							stock.lastUpdate = data.t
						})
					}
				}
			}
		}
	}
</script>

<style lang='scss' scoped>
	.value-positive
	{
		padding: 4px 8px;
		border-radius: 3px;
		background: palette('green');
		color: white;
	}

	.value-negative
	{
		padding: 4px 8px;
		border-radius: 3px;
		background: palette('red');
		color: white;
	}
</style>
